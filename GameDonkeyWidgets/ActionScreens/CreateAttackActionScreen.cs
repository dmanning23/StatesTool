using GameDonkeyLib;

namespace GameDonkeyWidgets
{
	public class CreateAttackActionScreen : TimedActionScreen
    {
		#region Properties

		#endregion //Properties

		#region Methods

		public CreateAttackActionScreen(BaseAction stateAction, PlayerQueue character) : base("Attack", stateAction, character)
		{
		}

		protected override void AddStateActionWidgets()
		{
			base.AddStateActionWidgets();

			var attackAction = StateAction as CreateAttackAction;

			var bone = AddBoneDropdown(this.Character.Character.AnimationContainer, ToolStack, false, attackAction.AttackBone, true);
			bone.SelectedItem = attackAction.AttackBone;
			bone.OnSelectedItemChange += (obj, e) =>
			{
				attackAction.BoneName = e.SelectedItem.Name;
			};
		}

		#endregion //Methods
	}
}
