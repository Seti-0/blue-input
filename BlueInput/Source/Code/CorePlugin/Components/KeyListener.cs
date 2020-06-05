using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Duality;
using Duality.Input;

using Duality.Editor;

namespace Soulstone.Duality.Plugins.BlueInput
{
    [EditorHintCategory(BlueInputCategoryNames.Components)]
    [RequiredComponent(typeof(MouseListener))]
    public class KeyListener : Component, ICmpKeyListener
    {
        public bool Global { get; set; } = false;

        public bool RequestFocus { get; set; } = false;

        [DontSerialize] private EventHandler _gainedFocus, _lostFocus;
        [DontSerialize] private EventHandler<KeyboardKeyEventArgs> _keyUp, _keyDown;

        public event EventHandler GainedFocus
        {
            add => _gainedFocus += value;
            remove => _gainedFocus -= value;
        }

        public event EventHandler LostFocus
        {
            add => _lostFocus += value;
            remove => _lostFocus -= value;
        }

        public event EventHandler<KeyboardKeyEventArgs> KeyUp
        {
            add => _keyUp += value;
            remove => _keyUp -= value;
        }

        public event EventHandler<KeyboardKeyEventArgs> KeyDown
        {
            add => _keyDown += value;
            remove => _keyDown -= value;
        }

        public void OnGainedFocus(EventArgs args)
        {
            _gainedFocus?.Invoke(this, args);
        }

        public void OnLostFocus(EventArgs args)
        {
            _lostFocus?.Invoke(this, args);
        }

        public void OnKeyUp(KeyboardKeyEventArgs args)
        {
            _keyUp?.Invoke(this, args);
        }

        public void OnKeyDown(KeyboardKeyEventArgs args)
        {
            _keyDown?.Invoke(this, args);
        }
    }
}
