using GameDonkeyLib;

namespace StatesTool
{
    public class SendToBackActionScreen : BaseActionScreen
    {
        #region Properties

        #endregion //Properties

        #region Methods

        public SendToBackActionScreen(BaseAction stateAction, PlayerQueue character) : base("Send To Back", stateAction, character)
        {
        }

        protected override void AddStateActionWidgets()
        {
        }

        #endregion //Methods
    }
}
