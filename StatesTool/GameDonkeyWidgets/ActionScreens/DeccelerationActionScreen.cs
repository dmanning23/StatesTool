using GameDonkeyLib;

namespace StatesTool
{
    public class DeccelerationActionScreen : BaseActionScreen
    {
        #region Methods

        public DeccelerationActionScreen(BaseAction stateAction, IPlayerQueue character) : base("Decceleration", stateAction, character)
        {
        }

        protected override void AddStateActionWidgets()
        {
            var action = StateAction as ConstantDeccelerationAction;

            AddActionDirectionControls(action.Velocity, ToolStack);

            //add a control to change the scale of the projectile
            CreateLabel("MinYVelocity", ToolStack);
            var scale = CreateNumEditBox(action.MinYVelocity, ToolStack);
            scale.OnNumberEdited += (obj, e) =>
            {
                action.MinYVelocity = scale.Number;
            };
        }

        #endregion //Methods
    }
}
