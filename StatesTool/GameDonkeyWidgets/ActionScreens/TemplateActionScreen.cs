using GameDonkeyLib;

namespace StatesTool
{
    public class TemplateActionScreen : BaseActionScreen
    {
        #region Methods

        public TemplateActionScreen(BaseAction stateAction, IPlayerQueue character) : base("Template Action", stateAction, character)
        {
        }

        protected override void AddStateActionWidgets()
        {
            var action = StateAction as TemplateAction;

            var button = CreateButton("Actions", ToolStack);
            button.OnClick += Button_OnClick;
        }

        private void Button_OnClick(object sender, InputHelper.ClickEventArgs e)
        {
            ScreenManager.AddScreen(new StateActionsScreen(Engine, Character, StateAction as TemplateAction, "Template Actions"));
        }

        #endregion //Methods
    }
}
