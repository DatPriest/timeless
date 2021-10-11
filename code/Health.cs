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
		public Label label;

		public Health()
		{
			StyleSheet.Load( "/ui/Health.scss" );
			label = Add.Label( "100", "value" );
		}

		public override void Tick()
		{
			var player = Local.Pawn;
			if ( player != null ) return;

			label.Text = $"{player.Health.CeilToInt()}";
			
		}
	}
}
