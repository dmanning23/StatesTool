using GameDonkeyLib;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameDonkeyWidgets
{
    public abstract class TimedActionScreen : BaseActionScreen
	{
		#region Properties

		#endregion //Properties

		#region Methods

		public TimedActionScreen(string screenName) : base(screenName)
		{
		}

		protected void AddTimeDeltaControl(TimedAction baseAction)
		{
			//TODO: add a control to change the time delta of the action
		}

		#endregion //Methods
	}
}
