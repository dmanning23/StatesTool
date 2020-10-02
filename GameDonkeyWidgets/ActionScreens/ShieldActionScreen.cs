using GameDonkeyLib;

namespace GameDonkeyWidgets
{
	public class ShieldActionScreen : TimedActionScreen
    {
		#region Properties

		#endregion //Properties

		#region Methods

		public ShieldActionScreen(BaseAction stateAction, PlayerQueue character) : base("Shield", stateAction, character)
		{
		}

		protected override void AddStateActionWidgets()
		{
			base.AddStateActionWidgets();
		}

		#endregion //Methods
	}
}
