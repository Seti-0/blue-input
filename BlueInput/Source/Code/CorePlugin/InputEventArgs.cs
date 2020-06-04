using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Duality;
using Duality.Input;

namespace Soulstone.Duality.Plugins.Blue.Input
{
    public class ResizeEventArgs : EventArgs
    {
        public Vector2 OldSize;
        public Vector2 NewSize;

        public ResizeEventArgs(Vector2 oldSize, Vector2 newSize)
        {
            OldSize = oldSize;
            NewSize = newSize;
        }
    }

    public class MouseDragEventArgs : MouseEventArgs
    {
        public Vector2 Origin;

        public MouseDragEventArgs(MouseInput inputChannel, Vector2 pos, Vector2 origin) : base(inputChannel, pos)
        {
            Origin = origin;
        }
    }
}
