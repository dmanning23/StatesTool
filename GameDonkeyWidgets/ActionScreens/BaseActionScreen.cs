using GameDonkeyLib;

namespace GameDonkeyWidgets
{
	public abstract class BaseActionScreen : GameDonkeyBaseTab
	{
		#region Properties

		protected BaseAction StateAction { get; set; }
		protected PlayerQueue Character { get; set; }

		public IGameDonkey Engine { get; set; }

		#endregion //Properties

		#region Methods

		public BaseActionScreen(string screenName, BaseAction stateAction, PlayerQueue character) : base(screenName)
		{
			StateAction = stateAction;
			Character = character;
		}

		public override void LoadContent()
		{
			base.LoadContent();

			//add the close button
			AddTitle(StateAction.ActionType.ToString(), false, ToolStack);

			//add the time
			AddTimeControl();

			AddStateActionWidgets();

			AddItem(ToolStack);
		}

		protected abstract void AddStateActionWidgets();

		protected void AddTimeControl()
		{
			//add a control to change the time of the action
			CreateLabel("Time", ToolStack);
			var time = CreateNumEditBox(StateAction.Time, ToolStack);
			time.OnNumberEdited += (obj, e) =>
			{
				StateAction.Time = time.Number;
			};
		}

		#endregion //Methods
	}
}
