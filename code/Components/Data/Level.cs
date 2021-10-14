using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sandbox;
using Sandbox.UI;
using Sandbox.UI.Construct;

namespace timeless.Components.Data
{
	public class Level
	{
		public int LevelAmount { get; set; } = 1;
		public float Experience { get; set; } = 0;
		public float ExperienceActualLevel { get; set; } = 0;
		public float ExperienceToNextLevel { get; set; } = 150;
		public BasePlayer Player { get; set; }

		public Level(BasePlayer player)
		{
			Experience = 0;
			Player = player;
			LevelAmount = 0;
		}

		public void CalculateExperience()
		{
			ExperienceActualLevel = 0;
			ExperienceToNextLevel = (float)ExperienceToNextLevel * 1.01f + 150;
		}
	}
}
