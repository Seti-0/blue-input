using Duality;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soulstone.Duality.Plugins.BlueInput
{
    public interface ICmpMouseDragListener : IManageableObject
    {
        void OnDragStart(MouseDragEventArgs args);

        void OnDragContinue(MouseDragEventArgs args);

        void OnDragEnd(MouseDragEventArgs args);
    }
}
