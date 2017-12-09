using GameDonkeyLib;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameDonkeyWidgets
{
	public class SendStateMessageActionScreen : BaseActionScreen
	{
		#region Properties

		#endregion //Properties

		#region Methods

		public SendStateMessageActionScreen(BaseAction stateAction, PlayerQueue character) : base("Send State Message", stateAction, character)
		{
		}

		protected override void AddStateActionWidgets()
		{
			var messageAction = StateAction as SendStateMessageAction;
			var message = AddStateMessageDropdown(Character.Character.States.StateMachine, ToolStack);
			message.SelectedItem = messageAction.MessageName;
			message.OnSelectedItemChange += (obj, e) =>
			{
				messageAction.MessageName = e.SelectedItem;
			};
		}

		#endregion //Methods
	}
}
