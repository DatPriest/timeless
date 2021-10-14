using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sandbox;

namespace timeless
{
	public partial class Game
	{
		[ServerCmd( "kill", Help = "Kills the calling player with generic damage" )]
		public new static void KillCommand()
		{
			var target = ConsoleSystem.Caller;
			if ( target == null ) return;

			(Current as Game)?.DoPlayerSuicide( target );
		}


	}
}
