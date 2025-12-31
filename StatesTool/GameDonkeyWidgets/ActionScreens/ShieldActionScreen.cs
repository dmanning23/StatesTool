using GameDonkeyLib;

namespace StatesTool
{
    public class ShieldActionScreen : TimedActionScreen
    {
        #region Properties

        #endregion //Properties

        #region Methods

        public ShieldActionScreen(BaseAction stateAction, IPlayerQueue character) : base("Shield", stateAction, character)
        {
        }

        protected override void AddStateActionWidgets()
        {
            base.AddStateActionWidgets();
        }

        #endregion //Methods
    }
}
