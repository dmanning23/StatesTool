using GameDonkeyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WidgetLib;
using InputHelper;
using GameDonkeyWidgets;

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

		public StateActionsScreen(IGameDonkey donkey, PlayerQueue character, StateActions stateActions) : base("State Actions Screen", true, true)
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
			throw new NotImplementedException();
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
			throw new NotImplementedException();
		}

		#endregion //Methods
	}
}
