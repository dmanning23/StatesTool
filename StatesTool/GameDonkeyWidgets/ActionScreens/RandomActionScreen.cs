using GameDonkeyLib;

namespace StatesTool
{
    public class RandomActionScreen : BaseActionScreen
    {
        #region Methods

        public RandomActionScreen(BaseAction stateAction, IPlayerQueue character) : base("Random Action", stateAction, character)
        {
        }

        protected override void AddStateActionWidgets()
        {
            var action = StateAction as RandomAction;

            var button = CreateButton("Actions", ToolStack);
            button.OnClick += Button_OnClick;
        }

        private void Button_OnClick(object sender, InputHelper.ClickEventArgs e)
        {
            ScreenManager.AddScreen(new StateActionsScreen(Engine, Character, StateAction as RandomAction, "Random Actions"));
        }

        #endregion //Methods
    }
}
