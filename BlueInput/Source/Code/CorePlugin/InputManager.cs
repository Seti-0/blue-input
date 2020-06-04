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
    // Todo: This is kinda silly, just replace the collection with 4 fields for the input listeners.
    internal class InputFocusCollection
    {
        private readonly Dictionary<Type, object> _focuses = new Dictionary<Type, object>();

        public void Clear()
        {
            _focuses.Clear();
        }

        public void ClearFocus<T>()
        {
            _focuses.Remove(typeof(T));
        }

        public void SetFocus<T>(T newFocus)
        {
            ClearFocus<T>();

            if (newFocus != null)
                _focuses.Add(typeof(T), newFocus);
        }

        public T GetFocus<T>()
        {
            if (!_focuses.TryGetValue(typeof(T), out object result))
                return default;

            return (T) result;
        }
    }

    public class InputManager : IDisposable
    {
        // I'm not sure DontSerialize is relevant here, would Duality ever serialize this?
        // Better safe than sorry, though.

        [DontSerialize] private InputFocusCollection _focuses = new InputFocusCollection();

        [DontSerialize] private bool _dragging;

        [DontSerialize] private Vector2 _currentDragOrigin;
        [DontSerialize] private MouseButton _currentDragButton;
        [DontSerialize] private MouseInput _currentDragInput;
        [DontSerialize] private ICmpMouseDragListener _currentDragTarget;

        [DontSerialize] private Vector2 _lastWindowSize;

        public ICmpMouseListener MouseFocus
        {
            get => _focuses.GetFocus<ICmpMouseListener>();
        }

        public ICmpMouseDragListener DragTarget
        {
            get => _focuses.GetFocus<ICmpMouseDragListener>();
        }

        public ICmpKeyListener KeyFocus
        {
            get => _focuses.GetFocus<ICmpKeyListener>();
        }

        private IEnumerable<T> GetGlobalListeners<T>() where T : class, ICmpLocalInputListener
        {
            var focus = _focuses.GetFocus<T>();

            var listeners = Scene.Current.FindComponents<T>()
                .Where(x => x.Global && x != focus);

            return listeners;
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
                foreach (var listener in Scene.Current.FindComponents<ICmpResizeListener>())
                    listener.OnWindowSizeChanged(new ResizeEventArgs(_lastWindowSize, DualityApp.TargetViewSize));

                _lastWindowSize = DualityApp.TargetViewSize;
            }
        }

        private void UpdateMouseFocus(EventArgs e)
        {
            ICmpMouseListener newFocus = GetNewFocus<ICmpMouseListener>();

            var currentFocus = _focuses.GetFocus<ICmpMouseListener>();

            if (currentFocus != newFocus)
            {
                currentFocus?.OnLostFocus(e);
                currentFocus = newFocus;
                currentFocus?.OnGainedFocus(e);
            }

            _focuses.SetFocus<ICmpMouseListener>(newFocus);
        }

        private void UpdateMouseWheelFocus(EventArgs e)
        {
            ICmpMouseWheelListener newFocus = GetNewFocus<ICmpMouseWheelListener>();
            var currentFocus = _focuses.GetFocus<ICmpMouseWheelListener>();

            if (currentFocus != newFocus)
            {
                _focuses.SetFocus<ICmpMouseWheelListener>(newFocus);
            }
        }

        private void InitializeKeyboardFocus()
        {
            ICmpKeyListener newFocus = Scene.Current.FindComponents<ICmpKeyListener>()
                    .Where(x => x.Active && x.RequestFocus)
                    .FirstOrDefault();

            if (newFocus == null)
                newFocus = Scene.Current.FindComponent<ICmpKeyListener>(activeOnly: true);

            var currentFocus = _focuses.GetFocus<ICmpKeyListener>();

            if (currentFocus != newFocus)
            {
                currentFocus?.OnLostFocus(new EventArgs());
                currentFocus = newFocus;
                currentFocus?.OnGainedFocus(new EventArgs());
            }

            _focuses.SetFocus<ICmpKeyListener>(newFocus);
        }

        private void UpdateKeyboardFocus(EventArgs e)
        {
            ICmpKeyListener newFocus = GetNewFocus<ICmpKeyListener>();

            var currentFocus = _focuses.GetFocus<ICmpKeyListener>();

            if (currentFocus != newFocus)
            {
                currentFocus?.OnLostFocus(e);
                currentFocus = newFocus;
                currentFocus?.OnGainedFocus(e);
            }

            _focuses.SetFocus<ICmpKeyListener>(newFocus);
        }

        private T GetNewFocus<T>() where T : class, IManageableObject
        {
            T newListener;

            if (_dragging)
            {
                // Don't assign new focuses while dragging, this gives unwanted behaviour when the mouse speeds ahead of the
                // object being dragged.
                
                // While this is the right behaviour for the mouse focus when a drag movement is used to move an object, I'm
                // not sure this is good general default behaviour. 

                newListener = _focuses.GetFocus<T>();
            }

            else TryGetComponentUnderMouse(out newListener);

            return newListener;
        }

        private bool TryGetComponentUnderMouse<T>(out T newListener) where T : class, IManageableObject
        {
            newListener = null;

            if (DualityApp.Mouse.IsAvailable)
            {
                TryGetComponentUnderMouse(out newListener, VisibilityFlag.Group1, ProjectionMode.Screen);

                if (newListener == null)
                    TryGetComponentUnderMouse(out newListener, VisibilityFlag.All & ~VisibilityFlag.Group1, ProjectionMode.Perspective);
            }

            return newListener != null;
        }

        private bool TryGetComponentUnderMouse<T>(out T listener, VisibilityFlag groups, ProjectionMode mode) where T : class, IManageableObject
        {
            // This has been an interesting experiment, but it is a bit delicate. The advantage is out-of-the-box pixel perfect mouse detecting for any renderer,
            // but the disadvantages are performance penalities, no flexibility*, and no easy way to fix bugs. Might be worth looking 
            // at making a manual alternative to this.

            // *One might want a bounding radius for items that are partially transparent or very small. 

            // Consider making the input manager a component, and this a property?
            var camera = Scene.Current.FindComponent<Camera>();

            if (camera == null)
            {
                listener = null;
                return false;
            }

            DualityApp.CalculateGameViewport(DualityApp.WindowSize, out Rect viewportRect, out Vector2 imageSize);

            var originalMask = camera.VisibilityMask;
            var originalProjection = camera.Projection;

            camera.VisibilityMask = groups;
            camera.Projection = mode;

            // This can be dodgy if there are cameras with custom render targets
            camera.RenderPickingMap(new Point2(MathF.RoundToInt(viewportRect.W), MathF.RoundToInt(viewportRect.H)),
                imageSize, true);

            var renderer = camera.PickRendererAt((int)DualityApp.Mouse.Pos.X, (int)DualityApp.Mouse.Pos.Y) as Component;

            var obj = renderer?.GameObj;
            listener = null;

            while ((listener == null || !listener.Active) && obj != null)
            {
                listener = obj.GetComponent<T>();
                obj = obj.Parent;
            }

            camera.VisibilityMask = originalMask;
            camera.Projection = originalProjection;

            return listener != null;
        }

        private void StartDrag(MouseInput input, MouseButton button)
        {
            _currentDragInput = input;
            _currentDragButton = button;
            _currentDragOrigin = _currentDragInput.Pos;

            // These two assignments need to happen before the global listeners are retrieved, lest 
            // the local listener be treated as a global and informed of the event twice.
            _currentDragTarget = GetNewFocus<ICmpMouseDragListener>();
            _focuses.SetFocus<ICmpMouseDragListener>(_currentDragTarget);

            // This (among other things) locks the current focuses, and so must happen after the previous two assignments.
            _dragging = true;

            var e = new MouseDragEventArgs(_currentDragInput, _currentDragInput.Pos,
                _currentDragButton, _currentDragInput.Vel, _currentDragOrigin);

            _currentDragTarget?.OnDragStart(e);

            foreach (var listener in GetGlobalListeners<ICmpMouseDragListener>())
                listener.OnDragStart(e);
        }

        private void ContinueDrag()
        {
            if (!_dragging)
                return;

            var e = new MouseDragEventArgs(_currentDragInput, _currentDragInput.Pos,
                _currentDragButton, _currentDragInput.Vel, _currentDragOrigin);

            _currentDragTarget?.OnDragContinue(e);

            foreach (var listener in GetGlobalListeners<ICmpMouseDragListener>())
                listener.OnDragContinue(e);
        }

        private void EndDrag()
        {
            if (!_dragging)
                return;

            _dragging = false;

            var e = new MouseDragEventArgs(_currentDragInput, _currentDragInput.Pos,
                _currentDragButton, _currentDragInput.Vel, _currentDragOrigin);

            _currentDragTarget?.OnDragEnd(e);

            _currentDragInput = null;

            foreach (var listener in GetGlobalListeners<ICmpMouseDragListener>())
                listener.OnDragEnd(e);

            // These two assignments need to happen after the global listeners are retrieved, lest 
            // the local listener be treated as a global and informed of the event twice.
            _currentDragTarget = null;
            _focuses.ClearFocus<ICmpMouseDragListener>();
        }

        private void Keyboard_KeyDown(object sender, KeyboardKeyEventArgs e)
        {
            _focuses.GetFocus<ICmpKeyListener>()?.OnKeyDown(e);
            
            foreach (var listener in GetGlobalListeners<ICmpKeyListener>())
                listener.OnKeyDown(e);
        }

        private void Keyboard_KeyUp(object sender, KeyboardKeyEventArgs e)
        {
            _focuses.GetFocus<ICmpKeyListener>()?.OnKeyUp(e);

            foreach (var listener in GetGlobalListeners<ICmpKeyListener>())
                listener.OnKeyUp(e);
        }

        private void Keyboard_NoLongerAvailable(object sender, EventArgs e)
        {
            UpdateKeyboardFocus(e);

            foreach (var listener in GetGlobalListeners<ICmpKeyListener>())
                listener.OnLostFocus(e);
        }

        private void Keyboard_BecomesAvailable(object sender, EventArgs e)
        {
            InitializeKeyboardFocus();

            foreach (var listener in GetGlobalListeners<ICmpKeyListener>())
                listener.OnGainedFocus(e);
        }

        private void Mouse_BecomesAvailable(object sender, EventArgs e)
        {
            UpdateMouseFocus(e);

            foreach (var listener in GetGlobalListeners<ICmpMouseListener>())
                listener.OnGainedFocus(e);
        }

        private void Mouse_NoLongerAvailable(object sender, EventArgs e)
        {
            EndDrag();
            UpdateMouseFocus(e);

            foreach (var listener in GetGlobalListeners<ICmpMouseListener>())
                listener.OnLostFocus(e);
        }

        private void Mouse_WheelChanged(object sender, MouseWheelEventArgs e)
        {
            UpdateMouseWheelFocus(e);
            _focuses.GetFocus<ICmpMouseWheelListener>()?.OnWheelChanged(e);

            foreach (var listener in GetGlobalListeners<ICmpMouseWheelListener>())
                listener.OnWheelChanged(e);
        }
        private void Mouse_Move(object sender, MouseMoveEventArgs e)
        {
            UpdateMouseFocus(e);
            _focuses.GetFocus<ICmpMouseListener>()?.OnMove(e);

            ContinueDrag();

            foreach (var listener in GetGlobalListeners<ICmpMouseListener>())
                listener.OnMove(e);
        }

        private void Mouse_ButtonUp(object sender, MouseButtonEventArgs e)
        {
            // Current only one general drag is supported. Silmultaneous drags with different buttons would be
            // a nice feature
            //if (e.Button == _currentDragButton)
            EndDrag();

            UpdateMouseFocus(e);
            _focuses.GetFocus<ICmpMouseListener>()?.OnButtonUp(e);

            UpdateKeyboardFocus(e);

            foreach (var listener in GetGlobalListeners<ICmpMouseListener>())
                listener.OnButtonUp(e);
        }

        private void Mouse_ButtonDown(object sender, MouseButtonEventArgs e)
        {
            // Only supporting one drag at a time for now anyways.
            //if(e.Button == _currentDragButton)
            EndDrag();
            
            UpdateMouseFocus(e);
            _focuses.GetFocus<ICmpMouseListener>()?.OnButtonDown(e);
            
            if(_currentDragTarget == null)
                StartDrag(e.InputChannel as MouseInput, e.Button);

            foreach (var listener in GetGlobalListeners<ICmpMouseListener>())
                listener.OnButtonDown(e);
        }
    }
}
