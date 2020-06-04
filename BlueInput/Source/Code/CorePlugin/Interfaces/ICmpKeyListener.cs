using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Duality;
using Duality.Input;

namespace Soulstone.Duality.Plugins.Blue.Input
{
    public interface ICmpKeyListener : IManageableObject
    {
        void OnKeyUp(KeyboardKeyEventArgs args);

        void OnKeyDown(KeyboardKeyEventArgs args);

        void OnAvailable(EventArgs e);

        void OnNoLongerAvailable(EventArgs e);
    }
}
