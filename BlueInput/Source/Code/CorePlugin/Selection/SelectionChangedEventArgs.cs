using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soulstone.Duality.Plugins.BlueInput.Selection
{
    public class SelectionChangedEventArgs<T> : EventArgs where T : class
    {
        public T NewSelection { get; set; }
        public T OldSelection { get; set; }

        public SelectionChangedEventArgs(T newSelection, T oldSelection)
        {
            NewSelection = newSelection;
            OldSelection = oldSelection;
        }
    }
}
