using GameDonkeyLib;

namespace StatesTool
{
    public class CreateHitCircleActionScreen : CreateAttackActionScreen
    {
        public CreateHitCircleActionScreen(BaseAction stateAction, IPlayerQueue character) : base("Hit Circle", stateAction, character)
        {
        }

        protected override void AddStateActionWidgets()
        {
            base.AddStateActionWidgets();

            var action = StateAction as CreateHitCircleAction;

            CreateLabel("Radius:", ToolStack);
            var radius = CreateNumEditBox(action.Radius, ToolStack);
            radius.OnNumberEdited += (obj, e) =>
            {
                action.Radius = e.Num;
            };

            var startOffset = AddVectorEdit("Start Offset", action.StartOffset, ToolStack);
            startOffset.OnVectorEdited += (obj, e) =>
            {
                action.StartOffset = e.Vector;
            };

            var velocity = AddVectorEdit("Velocity", action.Velocity, ToolStack);
            startOffset.OnVectorEdited += (obj, e) =>
            {
                action.Velocity = e.Vector;
            };
        }
    }
}
