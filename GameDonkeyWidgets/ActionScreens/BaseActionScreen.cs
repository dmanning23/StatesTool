using GameDonkeyLib;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameDonkeyWidgets
{
	public abstract class BaseActionScreen : GameDonkeyBaseTab
	{
		#region Properties

		#endregion //Properties

		#region Methods

		public BaseActionScreen(string screenName) : base(screenName)
		{
		}

		protected void AddTimeControl(BaseAction baseAction)
		{
			//TODO: add a control to change the time of the action
		}

		#endregion //Methods
	}
}
