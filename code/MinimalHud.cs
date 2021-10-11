using Sandbox.UI;
using Sandbox;
using timeless;

//
// You don't need to put things in a namespace, but it doesn't hurt.
//
namespace MinimalExample
{
	/// <summary>
	/// This is the HUD entity. It creates a RootPanel clientside, which can be accessed
	/// via RootPanel on this entity, or Local.Hud.
	/// </summary>
	public partial class MinimalHudEntity : Sandbox.HudEntity<RootPanel>
	{
		public MinimalHudEntity()
		{
			if ( IsClient )
			{
				RootPanel.SetTemplate( "/minimalhud.html" );
				RootPanel.StyleSheet.Load( "UI/SandboxHud.scss" );
				RootPanel.Add.Panel( "healthBack" );
				RootPanel.AddChild<NameTags>();
				RootPanel.AddChild<ChatBox>();
				RootPanel.AddChild<Health>();
				Log.Error( Health.ToString() );

			}
		}
	}

}
