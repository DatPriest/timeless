using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sandbox;
using Sandbox.UI;
using Sandbox.UI.Construct;

namespace timeless
{
	public class Health : Panel
	{
		public Label health;
		private Panel HealthBar;

		public Health()
		{
			StyleSheet.Load( "/ui/Health.scss" );
			Panel healthBack = Add.Panel( "healthBack" );
			Panel healthBarBack = healthBack.Add.Panel( "healthBarBack" );
			HealthBar = healthBarBack.Add.Panel( "healthBar" );

			health = healthBack.Add.Label( "0", "healthText" );
		}

		public override void Tick()
		{
			var player = Local.Pawn;

			base.Tick();

			if ( player == null ) return;

			if ( player is MinimalPlayer)
			{
				var x  = (MinimalPlayer) player;
				player.Health = x.since;
			}

			health.Text = $"{player.Health.CeilToInt()}";
			HealthBar.Style.Dirty();
			HealthBar.Style.Width = Length.Percent( player.Health );

			
		}
	}
}
