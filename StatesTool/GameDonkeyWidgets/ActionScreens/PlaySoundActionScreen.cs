using GameDonkeyLib;

namespace StatesTool
{
    public class PlaySoundActionScreen : BaseActionScreen
    {
        #region Properties

        #endregion //Properties

        #region Methods

        public PlaySoundActionScreen(BaseAction stateAction, IPlayerQueue character) : base("Play Sound", stateAction, character)
        {
        }

        protected override void AddStateActionWidgets()
        {
            var soundAction = StateAction as PlaySoundAction;

            var soundFiles = AddContentFileDropdown("Sound files:", string.Empty, ".wav", soundAction.SoundCueName, ToolStack);
            soundFiles.OnSelectedItemChange += (obj, e) =>
            {
                soundAction.SoundCueName = soundFiles.SelectedItem;
            };
        }

        #endregion //Methods
    }
}
