using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Duality;
using Duality.Drawing;
using Duality.Input;
using Duality.Components;
using Duality.Resources;

namespace Soulstone.Duality.Plugins.Blue.Input
{
    public class InputManager : IDisposable
    {
        // I'm not sure DontSerialize is relevant here, would Duality ever serialize this?
        // Better safe than sorry, though.

        [DontSerialize] private ICmpRenderer _mouseFocus;

        [DontSerialize] private bool _dragging;

        [DontSerialize] private Vector2 _currentDragOrigin;
        [DontSerialize] private MouseButton _currentDragButton;
        [DontSerialize] private MouseInput _currentDragInput;

        [DontSerialize] private Vector2 _lastWindowSize;

        public ICmpRenderer MouseFocus
        {
            get => _mouseFocus;
        }

        private IEnumerable<T> FindActiveComponents<T>() where T : class, IManageableObject
        {
            return Scene.Current.FindComponents<T>()
                .Where(x => x.Active);
        }

        public void Initialize()
        {
            DualityApp.Mouse.Move += Mouse_Move;
            DualityApp.Mouse.ButtonDown += Mouse_ButtonDown;
            DualityApp.Mouse.ButtonUp += Mouse_ButtonUp;
            DualityApp.Mouse.BecomesAvailable += Mouse_BecomesAvailable;
            DualityApp.Mouse.NoLongerAvailable += Mouse_NoLongerAvailable;
            DualityApp.Mouse.WheelChanged += Mouse_WheelChanged;

            DualityApp.Keyboard.KeyDown += Keyboard_KeyDown;
            DualityApp.Keyboard.KeyUp += Keyboard_KeyUp;
            DualityApp.Keyboard.BecomesAvailable += Keyboard_BecomesAvailable;
            DualityApp.Keyboard.NoLongerAvailable += Keyboard_NoLongerAvailable;

            _lastWindowSize = DualityApp.TargetViewSize;
        }

        public void Dispose()
        {
            EndDrag();

            DualityApp.Mouse.Move -= Mouse_Move;
            DualityApp.Mouse.ButtonDown -= Mouse_ButtonDown;
            DualityApp.Mouse.ButtonUp -= Mouse_ButtonUp;
            DualityApp.Mouse.BecomesAvailable -= Mouse_BecomesAvailable;
            DualityApp.Mouse.NoLongerAvailable -= Mouse_NoLongerAvailable;
            DualityApp.Mouse.WheelChanged -= Mouse_WheelChanged;

            DualityApp.Keyboard.KeyDown -= Keyboard_KeyDown;
            DualityApp.Keyboard.KeyUp -= Keyboard_KeyUp;
            DualityApp.Keyboard.BecomesAvailable -= Keyboard_BecomesAvailable;
            DualityApp.Keyboard.NoLongerAvailable -= Keyboard_NoLongerAvailable;
        }

        public void Update()
        {
            // I'd rather not call this every frame. 
            // Can one listen for window size changes?
            CheckWindowSize();
        }

        private void CheckWindowSize()
        {
            if (_lastWindowSize != DualityApp.TargetViewSize)
            {
                foreach (var listener in FindActiveComponents<ICmpResizeListener>())
                    listener.OnWindowSizeChanged(new ResizeEventArgs(_lastWindowSize, DualityApp.TargetViewSize));

                _lastWindowSize = DualityApp.TargetViewSize;
            }
        }

        private void UpdateMouseFocus()
        {
            _mouseFocus = GetRendererUnderMouse();
        }

        private ICmpRenderer GetRendererUnderMouse()
        {
            ICmpRenderer renderer = null;

            if (DualityApp.Mouse.IsAvailable)
            {
                renderer = GetRendererUnderMouse(VisibilityFlag.Group1, ProjectionMode.Screen);

                if (renderer == null)
                    renderer = GetRendererUnderMouse(VisibilityFlag.All & ~VisibilityFlag.Group1, ProjectionMode.Perspective);
            }

            return renderer;
        }

        private ICmpRenderer GetRendererUnderMouse(VisibilityFlag groups, ProjectionMode mode)
        {
            // This has been an interesting experiment, but it is a bit delicate. The advantage is out-of-the-box pixel perfect mouse detecting for any renderer,
            // but the disadvantages are performance penalities, no flexibility*, and no easy way to fix bugs. Might be worth looking 
            // at making a manual alternative to this.

            // *One might want a bounding radius for items that are partially transparent or very small. 

            // Consider making the input manager a component, and this a property?
            var camera = Scene.Current.FindComponent<Camera>();

            if (camera == null)
            {
                return null;
            }

            DualityApp.CalculateGameViewport(DualityApp.WindowSize, out Rect viewportRect, out Vector2 imageSize);

            var originalMask = camera.VisibilityMask;
            var originalProjection = camera.Projection;

            camera.VisibilityMask = groups;
            camera.Projection = mode;

            // This can be dodgy if there are cameras with custom render targets
            camera.RenderPickingMap(new Point2(MathF.RoundToInt(viewportRect.W), MathF.RoundToInt(viewportRect.H)),
                imageSize, true);

            ICmpRenderer renderer = camera.PickRendererAt((int)DualityApp.Mouse.Pos.X, (int)DualityApp.Mouse.Pos.Y);

            camera.VisibilityMask = originalMask;
            camera.Projection = originalProjection;

            return renderer;
        }

        private void StartDrag(MouseInput input, MouseButton button)
        {
            EndDrag();

            _currentDragInput = input;
            _currentDragButton = button;
            _currentDragOrigin = _currentDragInput.Pos;

            _dragging = true;

            var e = new MouseDragEventArgs(_currentDragInput, _currentDragInput.Pos,
                _currentDragButton, _currentDragInput.Vel, _currentDragOrigin);

            foreach (var listener in FindActiveComponents<ICmpMouseDragListener>())
                listener.OnDragStart(e);
        }

        private void ContinueDrag()
        {
            if (!_dragging)
                return;

            var e = new MouseDragEventArgs(_currentDragInput, _currentDragInput.Pos,
                _currentDragButton, _currentDragInput.Vel, _currentDragOrigin);

            foreach (var listener in FindActiveComponents<ICmpMouseDragListener>())
                listener.OnDragContinue(e);
        }

        private void EndDrag()
        {
            if (!_dragging)
                return;

            _dragging = false;

            var e = new MouseDragEventArgs(_currentDragInput, _currentDragInput.Pos,
                _currentDragButton, _currentDragInput.Vel, _currentDragOrigin);

            _currentDragInput = null;

            foreach (var listener in FindActiveComponents<ICmpMouseDragListener>())
                listener.OnDragEnd(e);
        }

        private void Keyboard_KeyDown(object sender, KeyboardKeyEventArgs e)
        {
            foreach (var listener in FindActiveComponents<ICmpKeyListener>())
                listener.OnKeyDown(e);
        }

        private void Keyboard_KeyUp(object sender, KeyboardKeyEventArgs e)
        {
            foreach (var listener in FindActiveComponents<ICmpKeyListener>())
                listener.OnKeyUp(e);
        }

        private void Keyboard_NoLongerAvailable(object sender, EventArgs e)
        {
            foreach (var listener in FindActiveComponents<ICmpKeyListener>())
                listener.OnNoLongerAvailable(e);
        }

        private void Keyboard_BecomesAvailable(object sender, EventArgs e)
        {
            foreach (var listener in FindActiveComponents<ICmpKeyListener>())
                listener.OnAvailable(e);
        }

        private void Mouse_BecomesAvailable(object sender, EventArgs e)
        {
            UpdateMouseFocus();

            foreach (var listener in FindActiveComponents<ICmpMouseListener>())
                listener.OnMouseEnter(e);
        }

        private void Mouse_NoLongerAvailable(object sender, EventArgs e)
        {
            EndDrag(); 
            UpdateMouseFocus();

            foreach (var listener in FindActiveComponents<ICmpMouseListener>())
                listener.OnMouseExit(e);
        }

        private void Mouse_WheelChanged(object sender, MouseWheelEventArgs e)
        {
            UpdateMouseFocus();

            foreach (var listener in FindActiveComponents<ICmpMouseWheelListener>())
                listener.OnWheelChanged(e);
        }
        private void Mouse_Move(object sender, MouseMoveEventArgs e)
        {
            UpdateMouseFocus();
            ContinueDrag();

            foreach (var listener in FindActiveComponents<ICmpMouseListener>())
                listener.OnMove(e);
        }

        private void Mouse_ButtonUp(object sender, MouseButtonEventArgs e)
        {
            // Current only one general drag is supported. Silmultaneous drags with different buttons would be
            // a nice feature
            EndDrag();

            UpdateMouseFocus();

            foreach (var listener in FindActiveComponents<ICmpMouseListener>())
                listener.OnButtonUp(e);
        }

        private void Mouse_ButtonDown(object sender, MouseButtonEventArgs e)
        {
            // Only supporting one drag at a time for now anyways.
            //if(e.Button == _currentDragButton)
            EndDrag();

            UpdateMouseFocus();

            StartDrag(e.InputChannel as MouseInput, e.Button);

            foreach (var listener in FindActiveComponents<ICmpMouseListener>())
                listener.OnButtonDown(e);
        }
    }
}
