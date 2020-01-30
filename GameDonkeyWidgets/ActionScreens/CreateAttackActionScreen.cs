using GameDonkeyLib;

namespace GameDonkeyWidgets
{
	public class CreateAttackActionScreen : TimedActionScreen
    {
		#region Properties

		#endregion //Properties

		#region Methods

		public CreateAttackActionScreen(BaseAction stateAction, PlayerQueue character) : this("Attack", stateAction, character)
		{
		}

		protected CreateAttackActionScreen(string screenName, BaseAction stateAction, PlayerQueue character) : base(screenName, stateAction, character)
		{
		}

		protected override void AddStateActionWidgets()
		{
			base.AddStateActionWidgets();

			var attackAction = StateAction as CreateAttackAction;
			attackAction.SetAttackBone(); //The bone won't be set unless the action has been run before.

			var bone = AddBoneDropdown(this.Character.Character.AnimationContainer, ToolStack, false, attackAction.AttackBone, true);
			bone.SelectedItem = attackAction.AttackBone;
			bone.OnSelectedItemChange += (obj, e) =>
			{
				attackAction.BoneName = e.SelectedItem.Name;
			};

			var aoe = AddCheckbox("AoE", attackAction.AoE, ToolStack);
			aoe.OnClick += (obj, e) =>
			{
				attackAction.AoE = aoe.IsChecked;
			};

			var button = CreateButton("Success Actions", ToolStack);
			button.OnClick += Button_OnClick;
		}
		
		private void Button_OnClick(object sender, InputHelper.ClickEventArgs e)
		{
			ScreenManager.AddScreen(new StateActionsScreen(Engine, Character, StateAction as CreateAttackAction, "Success Actions"));
		}

		#endregion //Methods
	}
}
