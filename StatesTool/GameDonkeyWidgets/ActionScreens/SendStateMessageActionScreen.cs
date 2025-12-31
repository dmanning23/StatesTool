using GameDonkeyLib;

namespace StatesTool
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
            message.SelectedItem = messageAction.Message;
            message.OnSelectedItemChange += (obj, e) =>
            {
                messageAction.Message = e.SelectedItem;
            };
        }

        #endregion //Methods
    }
}
