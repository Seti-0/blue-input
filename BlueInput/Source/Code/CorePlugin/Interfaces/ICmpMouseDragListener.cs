using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soulstone.Duality.Plugins.Blue.Input
{
    public interface ICmpMouseDragListener : ICmpLocalInputListener
    {
        void OnDragStart(MouseDragEventArgs args);

        void OnDragContinue(MouseDragEventArgs args);

        void OnDragEnd(MouseDragEventArgs args);
    }
}
