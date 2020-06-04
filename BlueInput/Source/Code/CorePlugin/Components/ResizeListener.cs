using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Duality;

using Duality.Editor;

namespace Soulstone.Duality.Plugins.Blue.Input
{
    [EditorHintCategory(BlueInputCategoryNames.Components)]
    public class ResizeListener : Component, ICmpResizeListener
    {
        public bool EditorUpdatable { get; set; } = false;

        [DontSerialize] private EventHandler<ResizeEventArgs> _windowSizeChanged;

        public event EventHandler<ResizeEventArgs> WindowSizeChanged
        {
            add => _windowSizeChanged += value;
            remove => _windowSizeChanged -= value;
        }

        public void OnWindowSizeChanged(ResizeEventArgs e)
        {
            _windowSizeChanged?.Invoke(this, e);
        }
    }
}
