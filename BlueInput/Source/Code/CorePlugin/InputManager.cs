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
using Duality.Editor;
using Soulstone.Duality.Plugins.Blue.Input.Selection;

namespace Soulstone.Duality.Plugins.Blue.Input
{
    [EditorHintCategory(CategoryNames.Components)]
    public class InputManager : Component, ICmpInitializable, ICmpUpdatable
    {
        public Camera Camera { get; set; }

        [DontSerialize] private ICmpRenderer _mouseFocus;

        [DontSerialize] private bool _dragging;
        [DontSerialize] private Vector2 _currentDragOrigin;


        [DontSerialize] private Vector2 _lastWindowSize;

        public ICmpRenderer MouseFocus
        {
            get => _mouseFocus;
        }

        public void OnActivate()
        {
            _lastWindowSize = DualityApp.TargetViewSize;

            SetupListeners();
        }

        public void OnDeactivate()
        {
            EndDrag();

            ClearListeners();
        }

        private void SetupListeners()
        {
            ClearListeners();

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
        }

        private void ClearListeners()
        {
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

        private IEnumerable<T> FindActiveComponents<T>() where T : class, IManageableObject
        {
            return Scene.FindComponents<T>()
                .Where(x => x.Active);
        }

        public void OnUpdate()
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
            // This has been an interesting experiment, but it is a bit delicate. 
            
            // The advantage is out-of-the-box pixel perfect mouse detecting for any renderer, which is lovely.
            // The disadvantages are possible performance penalities, no flexibility*, and no easy way to fix bugs. 

            // Might be worth looking at making a manual alternative to this.

            // *One might want a bounding radius for items that are partially transparent or very small. 

            var camera = Camera ?? Scene.FindComponent<Camera>();
            if (camera == null) return null;

            DualityApp.CalculateGameViewport(DualityApp.WindowSize, out Rect viewportRect, out Vector2 imageSize);
            var viewPortSize = new Point2(MathF.RoundToInt(viewportRect.W), MathF.RoundToInt(viewportRect.H));

            var renderSetup = camera.ActiveRenderSetup;

            var originalMask = camera.VisibilityMask;
            var originalProjection = camera.Projection;
            var originalRenderTarget = camera.Target;

            ICmpRenderer renderer = null;

            foreach (var step in Enumerable.Reverse(renderSetup.Steps))
            {
                // This section is very shaky. I very much doubt I've covered all the options in terms
                // of ways Cameras and RenderSetups can be configured.

                // I'm not sure about this in particular. Can the screen be a custom render target?
                // Not worrying about it for now though.
                if (step.Output != null) continue;

                camera.VisibilityMask = step.VisibilityMask;
                camera.Projection = step.Projection;
                camera.Target = null;

                // Currently, don't include the overlay. If this becomes important later I think
                // it should be done separately.
                bool renderOverlay = false;

                camera.RenderPickingMap(viewPortSize, imageSize, renderOverlay);

                renderer = camera.PickRendererAt((int)DualityApp.Mouse.Pos.X, (int)DualityApp.Mouse.Pos.Y);
                if (renderer != null) break;
            }

            camera.VisibilityMask = originalMask;
            camera.Projection = originalProjection;
            camera.Target = originalRenderTarget;

            return renderer;
        }

        private void StartDrag()
        {
            EndDrag();

            var input = DualityApp.Mouse;
            var pos = input.Pos;

            _currentDragOrigin = pos;
            _dragging = true;

            var e = new MouseDragEventArgs(input, pos: pos, origin: pos);

            foreach (var listener in FindActiveComponents<ICmpMouseDragListener>())
                listener.OnDragStart(e);
        }

        private void ContinueDrag()
        {
            if (!_dragging)
                return;

            var input = DualityApp.Mouse;
            var pos = input.Pos;

            var e = new MouseDragEventArgs(input, pos, _currentDragOrigin);

            foreach (var listener in FindActiveComponents<ICmpMouseDragListener>())
                listener.OnDragContinue(e);
        }

        private void EndDrag()
        {
            if (!_dragging)
                return;

            _dragging = false;

            var input = DualityApp.Mouse;
            var pos = input.Pos;

            var e = new MouseDragEventArgs(input, pos, _currentDragOrigin);

            foreach (var listener in FindActiveComponents<ICmpMouseDragListener>())
                listener.OnDragEnd(e);
        }

        private void UpdateSelections(SelectionTrigger trigger)
        {
            var selections = FindActiveComponents<ICmpSelection>();

            if (_dragging)
            {
                selections = selections.Where(x => !x.FreezeOnDrag);
            }

            foreach (var selection in selections)
                selection.Update(_mouseFocus, trigger);
        }

        private void Mouse_BecomesAvailable(object sender, EventArgs e)
        {
            if (!Active) return;

            UpdateMouseFocus();

            foreach (var listener in FindActiveComponents<ICmpMouseListener>())
                listener.OnMouseEnter(e);
        }

        private void Mouse_NoLongerAvailable(object sender, EventArgs e)
        {
            if (!Active) return;

            EndDrag();
            UpdateMouseFocus();

            foreach (var listener in FindActiveComponents<ICmpMouseListener>())
                listener.OnMouseExit(e);
        }

        private void Mouse_WheelChanged(object sender, MouseWheelEventArgs e)
        {
            if (!Active) return;

            UpdateMouseFocus();

            foreach (var listener in FindActiveComponents<ICmpMouseWheelListener>())
                listener.OnWheelChanged(e);
        }
        private void Mouse_Move(object sender, MouseMoveEventArgs e)
        {
            if (!Active) return;

            UpdateMouseFocus();
            UpdateSelections(SelectionTrigger.MouseOver);

            ContinueDrag();

            foreach (var listener in FindActiveComponents<ICmpMouseListener>())
                listener.OnMove(e);
        }

        private void Mouse_ButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (!Active) return;

            UpdateMouseFocus();
            UpdateSelections(SelectionTrigger.MouseUp);
            
            EndDrag();

            foreach (var listener in FindActiveComponents<ICmpMouseListener>())
                listener.OnButtonUp(e);
        }

        private void Mouse_ButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (!Active) return;

            // Only supporting one drag at a time for now anyways.
            //if(e.Button == _currentDragButton)
            EndDrag();

            UpdateMouseFocus();
            UpdateSelections(SelectionTrigger.MouseDown);

            StartDrag();

            foreach (var listener in FindActiveComponents<ICmpMouseListener>())
                listener.OnButtonDown(e);
        }

        private void Keyboard_KeyDown(object sender, KeyboardKeyEventArgs e)
        {
            if (!Active) return;

            foreach (var listener in FindActiveComponents<ICmpKeyListener>())
                listener.OnKeyDown(e);
        }

        private void Keyboard_KeyUp(object sender, KeyboardKeyEventArgs e)
        {
            if (!Active) return;

            foreach (var listener in FindActiveComponents<ICmpKeyListener>())
                listener.OnKeyUp(e);
        }

        private void Keyboard_NoLongerAvailable(object sender, EventArgs e)
        {
            if (!Active) return;

            foreach (var listener in FindActiveComponents<ICmpKeyListener>())
                listener.OnNoLongerAvailable(e);
        }

        private void Keyboard_BecomesAvailable(object sender, EventArgs e)
        {
            if (!Active) return;

            foreach (var listener in FindActiveComponents<ICmpKeyListener>())
                listener.OnAvailable(e);
        }
    }
}
