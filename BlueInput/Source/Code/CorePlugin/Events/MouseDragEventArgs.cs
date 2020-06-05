using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Duality;
using Duality.Input;

namespace Soulstone.Duality.Plugins.BlueInput
{
    public class MouseDragEventArgs : MouseEventArgs
    {
        public Vector2 Origin;

        public MouseDragEventArgs(MouseInput inputChannel, Vector2 pos, Vector2 origin) : base(inputChannel, pos)
        {
            Origin = origin;
        }
    }
}
