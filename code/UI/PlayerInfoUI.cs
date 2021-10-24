using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sandbox.UI;
using Sandbox;

namespace timeless.UI
{
	public class PlayerInfoUI : Panel
	{
		public Panel MainFrame;
		public PlayerInfoUI ()
		{
			StyleSheet.Load( "UI/PlayerInfoUI.scss" );
			Panel background = Add.Panel( "playerInfoBacktest" );
			Panel backgroundInfo = background.Add.Panel( "playerInfo" );
			MainFrame = backgroundInfo.Add.Panel( "playerInfoBack" );

			/*
			StyleSheet.Load( "/ui/Health.scss" );
			Panel healthBack = Add.Panel( "healthBack" );
			Panel healthBarBack = healthBack.Add.Panel( "healthBarBack" );
			HealthBar = healthBarBack.Add.Panel( "healthBar" );

			health = healthBack.Add.Label( "0", "healthText" );*/


		}

		public override void Tick()
		{
			var entity = Local.Pawn;

			base.Tick();

			if ( entity == null ) return;

			MainFrame.Style.Dirty();

		}
	}
}
