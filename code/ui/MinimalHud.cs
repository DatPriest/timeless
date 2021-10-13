﻿using Sandbox.UI;
using Sandbox;
using timeless;
using timeless.Components;

//
// You don't need to put things in a namespace, but it doesn't hurt.
//
namespace timeless
{
	/// <summary>
	/// This is the HUD entity. It creates a RootPanel clientside, which can be accessed
	/// via RootPanel on this entity, or Local.Hud.
	/// </summary>
	public partial class MinimalHudEntity : Sandbox.HudEntity<RootPanel>
	{
		public MinimalHudEntity()
		{
			if ( !IsClient ) return;
			
			RootPanel.AddChild<NameTags>();
			RootPanel.AddChild<ChatBox>();
			RootPanel.AddChild<Health>();
			RootPanel.AddChild<Level>();
		}
	}

}
