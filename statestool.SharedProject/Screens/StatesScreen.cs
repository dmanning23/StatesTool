using GameDonkeyLib;
using InputHelper;
using System;
using System.Linq;
using WidgetLib;

namespace StatesTool
{
	public class StatesScreen : ListScreen<SingleStateActions>
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

			Items = container.Actions.Actions.Values.OrderBy(x => x.StateName).ToList();
		}

		public override void AddItem(object obj, ClickEventArgs e)
		{
			throw new NotImplementedException();
		}

		public override void RemoveItem(SingleStateActions item)
		{
			throw new NotImplementedException();
		}

		public override void NavigateToItemScreen(SingleStateActions item)
		{
			ScreenManager.AddScreen(new StateActionsScreen(Engine, Character, item));
		}

		#endregion //Methods
	}
}
