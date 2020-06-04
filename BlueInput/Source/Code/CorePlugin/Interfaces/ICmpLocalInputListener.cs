using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Duality;

namespace Soulstone.Duality.Plugins.Blue.Input
{
    public interface ICmpLocalInputListener : IManageableObject
    {
        bool Global { get; }


    }
}
