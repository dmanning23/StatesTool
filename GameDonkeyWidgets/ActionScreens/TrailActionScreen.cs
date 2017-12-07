using GameDonkeyLib;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameDonkeyWidgets
{
	public class TrailActionScreen : TimedActionScreen
    {
		#region Properties

		#endregion //Properties

		#region Methods

		public TrailActionScreen(BaseAction stateAction, PlayerQueue character) : base("Trail", stateAction, character)
		{
		}

		protected override void AddStateActionWidgets()
		{
		}

		#endregion //Methods
	}
}
