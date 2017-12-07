using GameDonkeyLib;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameDonkeyWidgets
{
    public class ParticleEffectActionScreen : BaseActionScreen
	{
		#region Properties

		#endregion //Properties

		#region Methods

		public ParticleEffectActionScreen(BaseAction stateAction, PlayerQueue character) : base("Particle Effect", stateAction, character)
		{
		}

		protected override void AddStateActionWidgets()
		{
		}

		#endregion //Methods
	}
}
