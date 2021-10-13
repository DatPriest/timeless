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
	public class Health
	{
		public float MaxHealth { get; set; } = 250;
		public float Amount {  get; set; }

		public Health()
		{
			Amount = MaxHealth;
		}

	}
}
