using GameDonkeyLib;

namespace StatesTool
{
    public class TrailActionScreen : TimedActionScreen
    {
        #region Properties

        #endregion //Properties

        #region Methods

        public TrailActionScreen(BaseAction stateAction, PlayerQueue character) : base("Trail", stateAction, character)
        {
        }

        protected override void AddStateActionWidgets()
        {
            base.AddStateActionWidgets();

            var trailAction = StateAction as TrailAction;

            //start color
            var color = AddColorEdit("Color:", trailAction.StartColor, ToolStack);
            color.OnColorEdited += (obj, e) =>
            {
                trailAction.StartColor = e.Color;
            };

            //trail life
            CreateLabel("Trail Life:", ToolStack);
            var trailLife = CreateNumEditBox(trailAction.TrailLifeDelta, ToolStack);
            trailLife.OnNumberEdited += (obj, e) =>
            {
                trailAction.TrailLifeDelta = e.Num;
            };

            //spawn delta
            CreateLabel("Spawn Delta:", ToolStack);
            var spawn = CreateNumEditBox(trailAction.SpawnDelta, ToolStack);
            spawn.OnNumberEdited += (obj, e) =>
            {
                trailAction.SpawnDelta = e.Num;
            };
        }

        #endregion //Methods
    }
}
