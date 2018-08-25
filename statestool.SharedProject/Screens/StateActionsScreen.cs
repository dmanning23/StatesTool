using GameDonkeyLib;
using GameDonkeyWidgets;
using InputHelper;
using MenuBuddy;
using WidgetLib;

namespace StatesTool
{
	public class StateActionsScreen : ListScreen<BaseAction>
	{
		#region Properties

		IGameDonkey Engine { get; set; }
		PlayerQueue Character { get; set; }

		public StateActions StateActions { get; private set; }

		#endregion //Properties

		#region Methods

		public StateActionsScreen(IGameDonkey donkey, PlayerQueue character, StateActions stateActions) : base(stateActions.StateName, true, true)
		{
			CoveredByOtherScreens = true;
			CoverOtherScreens = true;

			Engine = donkey;
			Character = character;
			StateActions = stateActions;

			Items = StateActions.Actions;
		}

		public override void NavigateToItemScreen(BaseAction item)
		{
			var screen = ActionScreenFactory.CreateStateActionScreen(item, Character);
			screen.Engine = Engine;
			if (null == screen)
			{
				ScreenManager.AddScreen(new OkScreen($"Haven't completed the screen for {item.ActionType.ToString()} yet."));
			}
			else
			{
				ScreenManager.AddScreen(screen);
			}
		}

		public override void AddItem(object obj, ClickEventArgs e)
		{
			//get a name for the bone
			var msgBox = new StateActionTypeMessageBox();
			msgBox.OnSelect += (obj2, e2) =>
			{
				//add the bone to the skeleton
				var action = StateActions.AddNewActionFromType(msgBox.StateActionType.SelectedItem,
					Character.Character, Engine, Character.Character.States, this.Content);

				//add a button control for it
				CreateItemControl(action, false);
			};

			ScreenManager.AddScreen(msgBox);
		}

		public override void RemoveItem(BaseAction item)
		{
			base.RemoveItem(item);

			StateActions.RemoveAction(item);
		}

		#endregion //Methods
	}
}
