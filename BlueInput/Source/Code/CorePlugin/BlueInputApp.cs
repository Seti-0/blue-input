using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Duality;

namespace Soulstone.Duality.Plugins.Blue.Input
{
    public static class BlueInputApp
    {
        [DontSerialize] // I'm not sure Duality would ever serialize a static field, but just in case.
        private static InputManager _inputManager = null;

        public static InputManager Input
        {
            get => _inputManager;
        }

        public static void Init()
        {
            if (_inputManager == null)
            {
                _inputManager = new InputManager();
                _inputManager.Initialize();
            }
        }

        public static void Update()
        {
            _inputManager?.Update();
        }

        public static void Cleanup()
        {
            if (_inputManager != null)
            {
                _inputManager.Dispose();
                _inputManager = null;
            }
        }
    }
}
