using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Duality;

namespace Soulstone.Duality.Plugins.BlueInput.Selection
{
    public interface ICmpSelection : IManageableObject
    {
        SelectionTrigger SelectionTrigger { get; }

        bool FreezeOnDrag { get; }

        void Update(ICmpRenderer mouseFocus, SelectionTrigger trigger);
    }
}
