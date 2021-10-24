using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sandbox;
using Sandbox.UI;


namespace timeless
{
	partial class Game
	{

		/// <summary>
		/// Called clientside from OnKilled on the server to add kill messages to the killfeed. 
		/// </summary>
		[ClientRpc]
		public override void OnKilledMessage( ulong leftid, string left, ulong rightid, string right, string method )
		{
			Sandbox.UI.KillFeed.Current?.AddEntry( leftid, left, rightid, right, method );
		}
	}
}
