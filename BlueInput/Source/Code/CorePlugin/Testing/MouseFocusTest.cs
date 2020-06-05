using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Duality;
using Duality.Editor;

namespace Soulstone.Duality.Plugins.BlueInput.Testing
{
    [EditorHintCategory(CategoryNames.Testing)]
    public class MouseFocusTest : Component, ICmpUpdatable
    {
        public void OnUpdate()
        {
            var componentFocus = BlueInputApp.Input.MouseFocus;
            var name = (componentFocus as Component)?.GameObj?.Name ?? "<null>";

            VisualLogs.Default.DrawText(50, DualityApp.WindowSize.Y - 50, $"MouseFocus: {name}");
        }
    }
}
