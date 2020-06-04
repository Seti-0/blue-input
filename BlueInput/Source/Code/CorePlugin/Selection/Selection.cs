using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Duality;

namespace Soulstone.Duality.Plugins.Blue.Input.Selection
{
    public class Selection<T> : Component, ICmpSelection where T : class
    {
        public SelectionTrigger SelectionTrigger { get; set; }

        public bool FreezeOnDrag { get; set; }

        [DontSerialize] private T _value;
        [DontSerialize] private T _downValue;
        
        // This event is not really needed at the moment.
        //[DontSerialize] private EventHandler<SelectionChangedEventArgs<T>> _selectionChanged;

        public T Value
        {
            get => _value;
            set => _value = value;
        }
        
        /*public event EventHandler<SelectionChangedEventArgs<T>> ValueChanged
        {
            add => _selectionChanged += value;
            remove => _selectionChanged -= value;
        }*/

        public void Update(ICmpRenderer mouseFocus, SelectionTrigger trigger)
        {
            if (trigger == SelectionTrigger)
            {
                var newSelection = GetValue(mouseFocus);
                ApplySelection(newSelection);
            }

            else if (SelectionTrigger == SelectionTrigger.MouseClick)
            {
                if (trigger == SelectionTrigger.MouseDown)
                    _downValue = GetValue(mouseFocus);

                else if (trigger == SelectionTrigger.MouseUp)
                {
                    var newSelection = GetValue(mouseFocus);
                    if (_downValue == newSelection)
                        ApplySelection(newSelection);
                }
            }
        }

        private T GetValue(ICmpRenderer mouseFocus)
        {
            var target = (mouseFocus as Component)?.GameObj;
            T newSelection = null;

            while (newSelection == null && target != null)
            {
                newSelection = target.GetComponent<T>();
                target = target.Parent;
            }

            return newSelection;
        }

        private void ApplySelection(T newSelection)
        {
            if (_value != newSelection)
            {
                var oldSelection = _value;
                _value = newSelection;

                var e = new SelectionChangedEventArgs<T>(newSelection, oldSelection);
                OnValueChanged(e);
            }
        }

        protected virtual void OnValueChanged(SelectionChangedEventArgs<T> e)
        {
            //_selectionChanged?.Invoke(this, e);
        }
    }
}
