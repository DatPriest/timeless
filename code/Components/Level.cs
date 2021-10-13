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
	public class Level
	{
		public int LevelAmount { get; set; } = 1;
		public float Experience { get; set; } = 0;
		public float ExperienceActualLevel { get; set; } = 0;
		public float ExperienceToNextLevel { get; set; } = 150;

		public void CalculateExperience(BasePlayer player )
		{
			player.ExperienceActualLevel = 0;
			player.ExperienceToNextLevel = (float)(player.ExperienceToNextLevel * 1.01 + 150);
		}
	}
}
