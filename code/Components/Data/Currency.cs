using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sandbox.UI;
using Sandbox.UI.Construct;
using Sandbox;

namespace timeless.Components.Data
{
	public class Currency
	{
		public float Amount { get; set; }
		public string CurrencyName { get; set; }
		public BasePlayer Player {  get; set; }
		public Currency(BasePlayer player) 
		{
			Player = player;
			Amount = 0;
			CurrencyName = "Priestlings";
		}

		public void Pay(BasePlayer target, float amount)
		{
			if ( Amount < amount ) return;

			Transfer( target, amount );
		}

		public void Transfer(BasePlayer target, float amount)
		{
			Amount -= amount;
			target.Currency.Take( amount );
		}

		public void Take(float amount)
		{
			Amount += amount;
		}
	}


}
