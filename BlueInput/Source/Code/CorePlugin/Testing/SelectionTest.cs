using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Duality;
using Duality.Drawing;
using Duality.Components.Renderers;

using Soulstone.Duality.Plugins.BlueInput.Selection;
using Duality.Editor;

namespace Soulstone.Duality.Plugins.BlueInput.Testing
{
    [EditorHintCategory(CategoryNames.Testing)]
    public class SelectionTest : Selection<SpriteRenderer>, ICmpUpdatable
    {
        public int MessageChannel { get; set; } = 0;
        public float MessageLifetime { get; set; } = float.MaxValue;
        public ColorRgba Color { get; set; } = ColorRgba.Red;

        private double _messageTime;
        private string _messageContent;

        public void OnUpdate()
        {
            if (Time.MainTimer.TotalMilliseconds - _messageTime > MessageLifetime)
                return;

            if (string.IsNullOrWhiteSpace(_messageContent))
                return;

            for (int i = 0; i < 2; i++)
            {
                VisualLogs.Default
                   .DrawText(
                   300, 50 * (1 + MessageChannel), _messageContent)
                   .WithColor(Color);
            }
        }

        protected override void OnValueChanged(SelectionChangedEventArgs<SpriteRenderer> e)
        {
            if (e.OldSelection != null)
            {
                e.OldSelection.ColorTint = ColorRgba.White;
            }

            if (e.NewSelection != null)
            {
                e.NewSelection.ColorTint = Color;
            }

            _messageContent = $"{GameObj.Name}: Selection changed from " +
               $"{e.OldSelection?.GameObj.Name ?? "<null>"} to " +
               $"{e.NewSelection?.GameObj.Name ?? "<null>"}";
            _messageTime = Time.MainTimer.TotalMilliseconds;
        }
    }
}
