using MenuBuddy;
using Microsoft.Xna.Framework;
using StateMachineBuddy;

namespace GameDonkeyWidgets
{
	public class StateMessageDropdown : Dropdown<string>
	{
		#region Methods

		public StateMessageDropdown(StateMachine stateMachine, IScreen screen) : base(screen)
		{
			OnClick += CreateDropdownList;

			for (int i = 0; i < stateMachine.NumMessages; i++)
			{
				var message = stateMachine.GetMessageName(i);
				var dropitem = new DropdownItem<string>(message, this)
				{
					Vertical = VerticalAlignment.Center,
					Horizontal = HorizontalAlignment.Center,
					Size = new Vector2(330f, 48f)
				};

				var label = new Label(message, FontSize.Small)
				{
					Vertical = VerticalAlignment.Center,
					Horizontal = HorizontalAlignment.Center
				};

				dropitem.AddItem(label);
				AddDropdownItem(dropitem);
			}
		}

		#endregion //Methods
	}
}
