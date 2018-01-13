using GameDonkeyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WidgetLib;
using InputHelper;
using GameDonkeyWidgets;
using MenuBuddy;

namespace StatesTool
{
	public class StateActionsScreen : ListScreen<BaseAction>
	{
		#region Properties

		IGameDonkey Engine { get; set; }
		PlayerQueue Character { get; set; }

		StateActions StateActions { get; set; }

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
			if (null == screen)
			{
				screen = new OkScreen($"Haven't completed the screen for {item.ActionType.ToString()} yet.");
				
			}
			ScreenManager.AddScreen(screen);
		}

		public override void AddItem(object obj, ClickEventArgs e)
		{
			//get a name for the bone
			var msgBox = new StateActionTypeMessageBox();
			msgBox.OnSelect += (obj2, e2) =>
			{
				//add the bone to the skeleton
				var action = StateActions.AddNewActionFromType(msgBox.StateActionType.SelectedItem, Character.Character);

				//add a button control for it
				CreateItemControl(action);
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
