using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sandbox;

namespace timeless
{
	public class BaseBot : Bot
	{
		[AdminCmd("bot_custom", Help = "Spawn my custom bot.")]
		internal static void SpawnCustomBot()
		{
			Host.AssertServer();

			_ = new BaseBot();
		}

		public override void BuildInput(InputBuilder builder)
		{
			builder.SetButton( InputButton.Attack1 );
		}

		public override void Tick()
		{
			base.Tick();
			Log.Info( Client.Name );
		}
	}
}
