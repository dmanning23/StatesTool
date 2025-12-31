using GameDonkeyLib;

namespace StatesTool
{
    public class AccelerationActionScreen : BaseActionScreen
    {
        #region Methods

        public AccelerationActionScreen(BaseAction stateAction, IPlayerQueue character) : base("Acceleration", stateAction, character)
        {
        }

        protected override void AddStateActionWidgets()
        {
            var action = StateAction as ConstantAccelerationAction;

            AddActionDirectionControls(action.Velocity, ToolStack);

            //add a control to change the scale of the projectile
            CreateLabel("MaxVelocity", ToolStack);
            var scale = CreateNumEditBox(action.MaxVelocity, ToolStack);
            scale.OnNumberEdited += (obj, e) =>
            {
                action.MaxVelocity = scale.Number;
            };
        }

        #endregion //Methods
    }
}
