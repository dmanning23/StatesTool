using GameDonkeyLib;

namespace StatesTool
{
    public class BlockActionScreen : TimedActionScreen
    {
        #region Properties

        #endregion //Properties

        #region Methods

        public BlockActionScreen(BaseAction stateAction, IPlayerQueue character) : base("Block", stateAction, character)
        {
        }

        protected override void AddStateActionWidgets()
        {
            base.AddStateActionWidgets();

            var action = StateAction as BlockAction;
            action.SetAttackBone(); //The bone won't be set unless the action has been run before.

            var bone = AddBoneDropdown(this.Character.Character.AnimationContainer, ToolStack, false, action.AttackBone, true);
            bone.SelectedItem = action.AttackBone;
            bone.OnSelectedItemChange += (obj, e) =>
            {
                action.BoneName = e.SelectedItem.Name;
            };
        }

        #endregion //Methods
    }
}
