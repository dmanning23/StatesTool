using GameDonkeyLib;

namespace StatesTool
{
    public class AddVelocityActionScreen : BaseActionScreen
    {
        #region Methods

        public AddVelocityActionScreen(BaseAction stateAction, PlayerQueue character) : base("Add Velocity", stateAction, character)
        {
        }

        protected override void AddStateActionWidgets()
        {
            var action = StateAction as AddVelocityAction;

            AddActionDirectionControls(action.Velocity, ToolStack);
        }

        #endregion //Methods
    }
}
