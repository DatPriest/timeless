using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sandbox;
using Sandbox.UI;
using Sandbox.UI.Construct;

namespace timeless.UI
{
	public class LevelUI : Panel
	{
		public Label level;
		public Label experience;
		public Label experienceToNextLevel;
		private Panel LevelBar;

		public LevelUI()
		{
			StyleSheet.Load("/ui/Level.scss");
			Panel levelBack = Add.Panel("levelBack");
			Panel levelBarBack = levelBack.Add.Panel("levelBarBack");
			LevelBar = levelBarBack.Add.Panel("levelBar");

			level = levelBack.Add.Label("1", "levelText");
			experience = levelBack.Add.Label("1", "experience");
			experienceToNextLevel = levelBack.Add.Label("1", "experienceToNextLevel");
		}

		public override void Tick()
		{
			var entity = Local.Pawn;

			base.Tick();

			if (entity == null) return;

			if (entity is BasePlayer)
			{
				BasePlayer player = (BasePlayer)entity;
				if ( player.Level == null ) return;


				if (player.Level.Experience >= player.Level.ExperienceToNextLevel)
				{
					player.Level.LevelAmount++;
					player.Level.CalculateExperience();
				}

				level.Text = $"{player.Level.LevelAmount}";
				experience.Text = $"{player.Level.Experience}";
				experienceToNextLevel.Text = $"{player.Level.ExperienceToNextLevel}";
				LevelBar.Style.Dirty();
				LevelBar.Style.Width = Length.Percent((player.Level.ExperienceActualLevel / player.Level.ExperienceToNextLevel) * 100);
			}
		}
	}
}
