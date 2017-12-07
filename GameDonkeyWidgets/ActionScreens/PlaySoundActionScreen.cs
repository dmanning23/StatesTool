using GameDonkeyLib;

namespace GameDonkeyWidgets
{
	public class PlaySoundActionScreen : BaseActionScreen
    {
		#region Properties

		#endregion //Properties

		#region Methods

		public PlaySoundActionScreen(BaseAction stateAction, PlayerQueue character) : base("Play Sound", stateAction, character)
		{
		}

		protected override void AddStateActionWidgets()
		{
			var soundAction = StateAction as PlaySoundAction;

			var soundFiles = AddContentFileDropdown("Sound files:", ".wav", soundAction.SoundCueName, ToolStack);
			soundFiles.OnSelectedItemChange += (obj, e) =>
			{
				soundAction.SoundCueName = soundFiles.SelectedItem;
			};
		}

		#endregion //Methods
	}
}
