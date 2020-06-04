using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Duality;
using Duality.Resources;

namespace Soulstone.Duality.Plugins.Blue.Input
{
    public static class BlueInputApp
    {
        [DontSerialize] private static InputManager _manager;

        public static InputManager Input
        {
            get
            {
                if (_manager == null || _manager.Scene != Scene.Current)
                    _manager = Scene.Current.FindComponent<InputManager>();

                if (_manager == null)
                {
                    GameObject obj = new GameObject("Input Manager");
                    _manager = obj.AddComponent<InputManager>();
                    Scene.Current.AddObject(obj);
                }

                return _manager;
            }

            set => _manager = value;
        }
    }
}
