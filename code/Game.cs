
using Sandbox;
using Sandbox.UI;
using Sandbox.UI.Construct;
using System;
using System.IO;
using System.Threading.Tasks;
using timeless.UI;
using timeless.Components.Entity;
using timeless.Components.Data;
using timeless.Components.Controller;

//
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
	public partial class Game : Sandbox.Game
	{
		public new static Game Current { get; protected set; }
		public MinimalHudEntity hudEntity;
		public Game()
		{
			Current = this;
			if ( IsServer )
			{
				Log.Info( "My Gamemode Has Created Serverside!" );
				hudEntity = new MinimalHudEntity();
			}

			if ( IsClient )
			{
				Log.Info( "My Gamemode Has Created Clientside!" );
				hudEntity = new();
			}
		}

		public override void Shutdown()
		{
			if ( Current == this )
				Current = null;
		}

		public override void OnVoicePlayed( ulong steamId, float level )
		{
			VoiceList.Current?.OnVoicePlayed( steamId, level );
		}

		public override bool CanHearPlayerVoice( Client source, Client dest )
		{
			Host.AssertServer();

			var sp = source.Pawn;
			var dp = dest.Pawn;

			if ( sp == null || dp == null ) return false;
			if ( sp.Position.Distance( dp.Position ) > 1000 ) return false;

			return true;
		}


		public override void DoPlayerSuicide( Client cl )
		{

			if ( cl.Pawn == null ) return;
			/*if ( !cl.HasPermission( "kill" ) )
			{
				cl.Pawn.TakeDamage( DamageInfo.Generic( 1000 ) );
				Log.Info($"Player killed himself, {cl.Name}");
			}*/
			cl.Pawn.TakeDamage( DamageInfo.Generic( 1000 ) );
			Log.Info( $"Player killed himself, {cl.Name}" );

		}

		public override void DoPlayerNoclip( Client player )
		{
			if ( !player.HasPermission( "noclip" ) )
				return;

			if ( player.Pawn is Player basePlayer )
			{
				if ( basePlayer.DevController is NoclipController )
				{
					Log.Info( "Noclip Mode Off" );
					basePlayer.DevController = null;
				}
				else
				{
					Log.Info( "Noclip Mode On" );
					basePlayer.DevController = new NoclipController();
				}
			}
		}


		public override void BuildInput( InputBuilder input )
		{
			Event.Run( "buildinput", input );

			// the camera is the primary method here
			LastCamera?.BuildInput( input );

			Local.Pawn?.BuildInput( input );
		}

		public override void FrameSimulate( Client cl )
		{
			Host.AssertClient();

			if ( !cl.Pawn.IsValid() ) return;

			// Block Simulate from running clientside
			// if we're not predictable.
			if ( !cl.Pawn.IsAuthority ) return;

			cl.Pawn?.FrameSimulate( cl );
		}



		[Event.Hotload]
		public void HotLoadUpdate()
		{

			if ( !IsClient ) return;
			hudEntity?.Delete();
			hudEntity = new();
			((BasePlayer)Local.Pawn).Level.Experience += 1;
		}

		/// <summary>
		/// A client has joined the server. Make them a pawn to play with
		/// </summary>
		public override void ClientJoined( Client client )
		{
			BasePlayer player = new BasePlayer();
			client.Pawn = player;

			player.Respawn();
			PlayerDataController.InsertData( player );
		}

		/// <summary>
		/// Client has disconnected from the server. Remove their entities etc.
		/// </summary>
		public override void ClientDisconnect( Client cl, NetworkDisconnectionReason reason )
		{
			PlayerDataController.InsertData((BasePlayer)cl.Pawn);
			PlayerDataController.PrintData( );

			Log.Info( $"\"{cl.Name}\" has left the game ({reason})" );
			ChatBox.AddInformation( To.Everyone, $"{cl.Name} has left ({reason})", $"avatar:{cl.SteamId}" );

			if ( cl.Pawn.IsValid() )
			{
				cl.Pawn.Delete();
				cl.Pawn = null;
			}

		}

		public override void PostLevelLoaded()
		{
		}
	}

}
