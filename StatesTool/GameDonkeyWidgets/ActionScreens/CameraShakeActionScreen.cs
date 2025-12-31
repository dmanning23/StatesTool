using GameDonkeyLib;

namespace StatesTool
{
    public class CameraShakeActionScreen : BaseActionScreen
    {
        #region Properties

        #endregion //Properties

        #region Methods

        public CameraShakeActionScreen(BaseAction stateAction, IPlayerQueue character) : base("Camera Shake", stateAction, character)
        {
        }

        protected override void AddStateActionWidgets()
        {
            var cameraShakeAction = StateAction as CameraShakeAction;

            CreateLabel("Time Delta", ToolStack);
            var time = CreateNumEditBox(cameraShakeAction.TimeDelta, ToolStack);
            time.OnNumberEdited += (obj, e) =>
            {
                cameraShakeAction.TimeDelta = time.Number;
            };

            CreateLabel("Shake Amount", ToolStack);
            var shake = CreateNumEditBox(cameraShakeAction.ShakeAmount, ToolStack);
            shake.OnNumberEdited += (obj, e) =>
            {
                cameraShakeAction.ShakeAmount = shake.Number;
            };
        }

        #endregion //Methods
    }
}
