using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Duality;

namespace Soulstone.Duality.Plugins.Blue.Input
{
	public class BlueInputPlugin : CorePlugin
	{
		protected override void InitPlugin()
		{
			BlueInputApp.Init();
		}

		protected override void OnDisposePlugin()
		{
			BlueInputApp.Cleanup();
		}

		protected override void OnBeforeUpdate()
		{
			BlueInputApp.Update();
		}
	}
}
