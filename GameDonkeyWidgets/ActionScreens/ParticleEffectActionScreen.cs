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
			var particleAction = StateAction as ParticleEffectAction;

			//add the start offset 
			var color = AddColorEdit("Color:", particleAction.Emitter.ParticleColor, ToolStack);
			color.OnColorEdited += (obj, e) =>
			{
				particleAction.Emitter.ParticleColor = e.Color;
			};
		}

		#endregion //Methods
	}
}
