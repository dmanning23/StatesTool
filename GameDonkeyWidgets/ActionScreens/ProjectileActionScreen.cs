using GameDonkeyLib;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameDonkeyWidgets
{
	public class ProjectileActionScreen : BaseActionScreen
	{
		#region Properties

		#endregion //Properties

		#region Methods

		public ProjectileActionScreen(BaseAction stateAction, PlayerQueue character) : base("Projectile", stateAction, character)
		{
		}

		protected override void AddStateActionWidgets()
		{
		}

		#endregion //Methods
	}
}
