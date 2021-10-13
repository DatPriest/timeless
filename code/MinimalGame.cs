
using Sandbox;
using Sandbox.UI.Construct;
using System;
using System.IO;
using System.Threading.Tasks;

//
// Test Push2
// Test Push3
// You don't need to put things in a namespace, but it doesn't hurt.
//
namespace timeless
{

	/// <summary>
	/// This is your game class. This is an entity that is created serverside when
	/// the game starts, and is replicated to the client. 
	/// 
	/// You can use this to create things like HUDs and declare which player class
	/// to use for spawned players.
	/// </summary>
	public partial class MinimalGame : Sandbox.Game
	{
		public MinimalHudEntity hudEntity;
		public float t;
		public MinimalGame()
		{
			if ( IsServer )
			{
				Log.Info( "My Gamemode Has Created Serverside!" );

				// Create a HUD entity. This entity is globally networked
				// and when it is created clientside it creates the actual
				// UI panels. You don't have to create your HUD via an entity,
				// this just feels like a nice neat way to do it.
				hudEntity = new MinimalHudEntity();
			}

			if ( IsClient )
			{
				Log.Info( "My Gamemode Has Created Clientside!" );
				hudEntity = new();
			}
		}

		[Event.Hotload]
		public void HotLoadUpdate()
		{
			if ( !IsClient ) return;
			hudEntity?.Delete();
			hudEntity = new();

		}

		/// <summary>
		/// A client has joined the server. Make them a pawn to play with
		/// </summary>
		public override void ClientJoined( Client client )
		{
			base.ClientJoined( client );

			var player = new BasePlayer();
			client.Pawn = player;

			player.Respawn();
		}
	}

}
