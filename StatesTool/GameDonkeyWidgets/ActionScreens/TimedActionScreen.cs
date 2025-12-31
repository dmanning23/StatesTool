using GameDonkeyLib;

namespace StatesTool
{
    public abstract class TimedActionScreen : BaseActionScreen
    {
        #region Properties

        #endregion //Properties

        #region Methods

        public TimedActionScreen(string screenName, BaseAction stateAction, IPlayerQueue character) : base(screenName, stateAction, character)
        {
        }

        protected override void AddStateActionWidgets()
        {
            var timedAction = StateAction as TimedAction;

            //Add the time delta widget
            CreateLabel("Time Delta", ToolStack);
            var time = CreateNumEditBox(timedAction.TimeDelta, ToolStack);
            time.OnNumberEdited += (obj, e) =>
            {
                timedAction.TimeDelta = time.Number;
            };
        }

        #endregion //Methods
    }
}
