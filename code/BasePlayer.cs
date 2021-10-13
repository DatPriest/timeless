using Sandbox;
using System;
using System.Linq;
using Sandbox.UI;
using Sandbox.UI.Construct;
using timeless.Components;

namespace timeless
{
	public class BasePlayer : Player
	{
		public const int MaxHealth = 250;
		public TimeSince time;
		public int Level { get; set; } = 1;
		public float Experience { get; set; } = 0;
		public float ExperienceActualLevel { get; set; } = 0;
		public float ExperienceToNextLevel { get; set; } = 150;
		public BaseInventory inventory;
		public Currency Currency { get; set; }
		public Job Job { get; set; }
		public new Health Health { get; set; }

		public BasePlayer()
		{
			Currency = new Currency(this);
			inventory = new BaseInventory(this);
		}

		public override void Respawn()
		{
			SetModel( "models/citizen/citizen.vmdl" );
			Health = new();
			//
			// Use WalkController for movement (you can make your own PlayerController for 100% control)
			//
			Controller = new WalkController();

			//
			// Use StandardPlayerAnimator  (you can make your own PlayerAnimator for 100% control)
			//
			Animator = new StandardPlayerAnimator();

			//
			// Use ThirdPersonCamera (you can make your own Camera for 100% control)
			//
			Camera = new ThirdPersonCamera();


			EnableAllCollisions = true;
			EnableDrawing = true;
			EnableHideInFirstPerson = true;
			EnableShadowInFirstPerson = true;
			base.Respawn();
		}


		/// <summary>
		/// Called every tick, clientside and serverside.
		/// </summary>
		public override void Simulate( Client cl )
		{
			base.Simulate( cl );

			//
			// If you have active children (like a weapon etc) you should call this to 
			// simulate those too.
			//
			SimulateActiveChild( cl, ActiveChild );

			//
			// If we're running serverside and Attack1 was just pressed, spawn a ragdoll
			//
			if ( IsServer && Input.Pressed( InputButton.Attack1 ) )
			{
				var ragdoll = new ModelEntity();
				ragdoll.SetModel( "models/citizen/citizen.vmdl" );
				ragdoll.Position = EyePos + EyeRot.Forward * 40;
				ragdoll.Rotation = Rotation.LookAt( Vector3.Random.Normal );
				ragdoll.SetupPhysicsFromModel( PhysicsMotionType.Dynamic, false );
				ragdoll.PhysicsGroup.Velocity = EyeRot.Forward * 1000;
			}
			if (IsClient && Input.Pressed( InputButton.Attack1 ))
			{
				BasePlayer player = (BasePlayer)Local.Pawn;
				player.Experience++;
				player.ExperienceActualLevel++;

			}
		}


		public override void OnKilled()
		{
			base.OnKilled();

			EnableDrawing = false;
		}
	}
}
