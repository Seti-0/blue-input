using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Duality;
using Duality.Input;

namespace Soulstone.Duality.Plugins.BlueInput
{
    public interface ICmpMouseListener : IManageableObject
    {
        void OnMouseEnter(EventArgs args);

        void OnMouseExit(EventArgs args);

        void OnMove(MouseMoveEventArgs args);

        void OnButtonDown(MouseButtonEventArgs args);

        void OnButtonUp(MouseButtonEventArgs args);
    }
}
