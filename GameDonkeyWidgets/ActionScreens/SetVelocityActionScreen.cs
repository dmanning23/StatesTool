using GameDonkeyLib;

namespace GameDonkeyWidgets
{
	public class SetVelocityActionScreen : BaseActionScreen
	{
		#region Methods

		public SetVelocityActionScreen(BaseAction stateAction, PlayerQueue character) : base("Set Velocity", stateAction, character)
		{
		}

		protected override void AddStateActionWidgets()
		{
			var action = StateAction as SetVelocityAction;

			AddActionDirectionControls(action.Velocity, ToolStack);
		}

		#endregion //Methods
	}
}
