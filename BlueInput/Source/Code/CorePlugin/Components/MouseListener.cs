using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Duality;
using Duality.Input;

using Duality.Editor;

namespace Soulstone.Duality.Plugins.Blue.Input
{
    [EditorHintCategory(BlueInputCategoryNames.Components)]
    public class MouseListener : Component, ICmpMouseListener, ICmpMouseDragListener, ICmpMouseWheelListener
    {
        public bool Global { get; set; } = false;

        public bool EditorUpdatable { get; set; } = false;

        [DontSerialize] private EventHandler _entered, _exited;
        [DontSerialize] private EventHandler<MouseMoveEventArgs> _move;
        [DontSerialize] private EventHandler<MouseButtonEventArgs> _buttonDown, _buttonUp;
        [DontSerialize] private EventHandler<MouseWheelEventArgs> _wheelChanged;
        [DontSerialize] private EventHandler<MouseDragEventArgs> _dragStart, _dragContinue, _dragEnd;

        #region Event properties
        public event EventHandler Entered
        {
            add => _entered += value;
            remove => _entered -= value;
        }

        public event EventHandler Exited
        {
            add => _exited += value;
            remove => _exited -= value;
        }

        public event EventHandler<MouseMoveEventArgs> Move
        {
            add => _move += value;
            remove => _move -= value;
        }

        public event EventHandler<MouseButtonEventArgs> ButtonDown
        {
            add => _buttonDown += value;
            remove => _buttonDown -= value;
        }

        public event EventHandler<MouseButtonEventArgs> ButtonUp
        {
            add => _buttonUp += value;
            remove => _buttonUp -= value;
        }

        public event EventHandler<MouseWheelEventArgs> WheelChanged
        {
            add => _wheelChanged += value;
            remove => _wheelChanged -= value;
        }

        public event EventHandler<MouseDragEventArgs> DragStart
        {
            add => _dragStart += value;
            remove => _dragStart -= value;
        }

        public event EventHandler<MouseDragEventArgs> DragContinue
        {
            add => _dragContinue += value;
            remove => _dragContinue -= value;
        }

        public event EventHandler<MouseDragEventArgs> DragEnd
        {
            add => _dragEnd += value;
            remove => _dragEnd -= value;
        }
        #endregion

        public void OnGainedFocus(EventArgs args)
        {
            _entered?.Invoke(this, args);
        }

        public void OnLostFocus(EventArgs args)
        {
            _exited?.Invoke(this, args);
        }

        public void OnMove(MouseMoveEventArgs args)
        {
            _move?.Invoke(this, args);
        }

        public void OnButtonDown(MouseButtonEventArgs args)
        {
            _buttonDown?.Invoke(this, args);
        }

        public void OnButtonUp(MouseButtonEventArgs args)
        {
            _buttonUp?.Invoke(this, args);
        }

        public void OnWheelChanged(MouseWheelEventArgs args)
        {
            _wheelChanged?.Invoke(this, args);
        }

        public void OnDragStart(MouseDragEventArgs args)
        {
            _dragStart?.Invoke(this, args);
        }

        public void OnDragContinue(MouseDragEventArgs args)
        {
            _dragContinue?.Invoke(this, args);
        }

        public void OnDragEnd(MouseDragEventArgs args)
        {
            _dragEnd?.Invoke(this, args);
        }
    }
}
