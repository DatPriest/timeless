using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sandbox;
using Sandbox.UI;
using Sandbox.UI.Construct;

namespace timeless.Components
{
	public class Level : Panel
	{
		public Label level;
		public Label experience;
		public Label experienceToNextLevel;
		private Panel LevelBar;

		public Level()
		{
			StyleSheet.Load( "/ui/Level.scss" );
			Panel levelBack = Add.Panel( "levelBack" );
			Panel levelBarBack = levelBack.Add.Panel( "levelBarBack" );
			LevelBar = levelBarBack.Add.Panel( "levelBar" );

			level = levelBack.Add.Label( "1", "levelText" );
			experience = levelBack.Add.Label( "1", "experience" );
			experienceToNextLevel = levelBack.Add.Label( "1", "experienceToNextLevel" );
		}

		public override void Tick()
		{
			var entity = Local.Pawn;

			base.Tick();

			if ( entity == null ) return;

			if ( entity is BasePlayer )
			{
				BasePlayer player = (BasePlayer)entity;
				player.Level = 1;

				if (player.Experience >= player.ExperienceToNextLevel)
				{
					player.Level++;
					CalculateExperience( player );
				}

				level.Text = $"{player.Level}";
				experience.Text = $"{player.Experience}";
				experienceToNextLevel.Text = $"{player.ExperienceToNextLevel}";
				LevelBar.Style.Dirty();
				LevelBar.Style.Width = Length.Percent((player.ExperienceActualLevel / player.ExperienceToNextLevel) * 100); 
			}
		}

		public void CalculateExperience(BasePlayer player )
		{
			player.ExperienceActualLevel = 0;
			player.ExperienceToNextLevel = (float)(player.ExperienceToNextLevel * 1.01 + 150);
		}
	}
}
