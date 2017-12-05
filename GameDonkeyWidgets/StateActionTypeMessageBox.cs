using MenuBuddy;
using Microsoft.Xna.Framework;

namespace GameDonkeyWidgets
{
	public class StateActionTypeMessageBox : MessageBoxScreen
	{
		public StateActionTypeDropdown StateActionType { get; set; }

		public StateActionTypeMessageBox() : base("State action type:", "")
		{
		}

		protected override void AddAddtionalControls()
		{
			base.AddAddtionalControls();

			//add a shim between the text and the buttons
			ControlStack.AddItem(new Shim() { Size = new Vector2(0, 16f) });

			//add the edit box to change the language resource
			StateActionType = new StateActionTypeDropdown(this)
			{
				Size = new Vector2(768f, 32f),
				Horizontal = HorizontalAlignment.Center,
				Vertical = VerticalAlignment.Center,
				HasBackground = true
			};

			//add the dropdown to the controlstack
			ControlStack.AddItem(StateActionType);
		}
	}
}
