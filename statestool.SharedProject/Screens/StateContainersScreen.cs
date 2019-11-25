using GameDonkeyLib;
using GameDonkeyWidgets;
using MenuBuddy;
using System.Threading.Tasks;

namespace StatesTool
{
	public class StateContainersScreen : GameDonkeyBaseTab
	{
		#region Properties

		IGameDonkey Engine { get; set; }
		PlayerQueue Character { get; set; }

		#endregion //Properties

		#region Methods

		public StateContainersScreen(IGameDonkey donkey, PlayerQueue character) :base("StateContainers")
		{
			CoveredByOtherScreens = true;
			CoverOtherScreens = true;

			Engine = donkey;
			Character = character;

			Layer = -200;
		}

		public override async Task LoadContent()
		{
			await base.LoadContent();

			var dropdown = AddStateContainerDropdown(Character.Character.States, ToolStack);
			dropdown.OnSelectedItemChange += Dropdown_OnSelectedItemChange;

			AddItem(ToolStack);
		}

		private async void Dropdown_OnSelectedItemChange(object sender, SelectionChangeEventArgs<IStateContainer> e)
		{
			var container = e.SelectedItem as SingleStateContainer;
			if (null != container)
			{
				await ScreenManager.AddScreen(new StatesScreen(Engine, Character, container));
			}
		}

		#endregion //Methods
	}
}
