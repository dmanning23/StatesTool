using AnimationLib;
using GameDonkeyLib;
using UndoRedoBuddy;

namespace StatesTool
{
    public class PlayAnimationActionScreen : BaseActionScreen
    {
        #region Properties

        #endregion //Properties

        #region Methods

        public PlayAnimationActionScreen(BaseAction stateAction, PlayerQueue character) : base("Play Animation", stateAction, character)
        {
        }

        protected override void AddStateActionWidgets()
        {
            var animationAction = StateAction as PlayAnimationAction;

            var tempStack = new UndoRedoStack();
            var animation = AddAnimationDropdown(Character.Character.AnimationContainer, tempStack, ToolStack);

            if (!string.IsNullOrEmpty(animationAction.AnimationName))
            {
                var selectedAnimation = Character.Character.AnimationContainer.FindAnimation(animationAction.AnimationName);
                animation.SelectedItem = Character.Character.AnimationContainer.FindAnimation(animationAction.AnimationName);
            }

            animation.OnSelectedItemChange += (obj, e) =>
            {
                animationAction.AnimationName = animation.SelectedItem.Name;
            };

            var playback = AddPlaybackTypeDropdown(EPlayback.Forwards, ToolStack);
            playback.SelectedItem = animationAction.PlaybackMode;
            playback.OnSelectedItemChange += (obj, e) =>
            {
                animationAction.PlaybackMode = playback.SelectedItem;
            };
        }

        #endregion //Methods
    }
}
