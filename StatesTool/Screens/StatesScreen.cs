using GameDonkeyLib;
using InputHelper;
using System;
using WidgetLib;

namespace StatesTool
{
	public class StatesScreen : ListScreen<StateActions>
	{
		#region Properties

		IGameDonkey Engine { get; set; }
		PlayerQueue Character { get; set; }

		IStateContainer StateContainer { get; set; }

		#endregion //Properties

		#region Methods

		public StatesScreen(IGameDonkey donkey, PlayerQueue character, SingleStateContainer container) : base(null, container.Name, false, false)
		{
			CoveredByOtherScreens = true;
			CoverOtherScreens = true;

			Engine = donkey;
			Character = character;

			Items = container.Actions.Actions;
		}

		public override void AddItem(object obj, ClickEventArgs e)
		{
			throw new NotImplementedException();
		}

		public override void RemoveItem(StateActions item)
		{
			throw new NotImplementedException();
		}

		public override void NavigateToItemScreen(StateActions item)
		{
			ScreenManager.AddScreen(new StateActionsScreen(Engine, Character, item));
		}

		#endregion //Methods
	}
}
