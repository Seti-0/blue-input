using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Duality;

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
}
