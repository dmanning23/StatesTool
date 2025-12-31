using GameDonkeyLib;

namespace StatesTool
{
    public class ProjectileActionScreen : BaseActionScreen
    {
        #region Properties

        #endregion //Properties

        #region Methods

        public ProjectileActionScreen(BaseAction stateAction, IPlayerQueue character) : base("Projectile", stateAction, character)
        {
        }

        protected override void AddStateActionWidgets()
        {
            var projectileAction = StateAction as ProjectileAction;

            ////change the projectile data file
            //var dataFile = AddContentFileDropdown("Data file:", projectileAction.FileName.GetPath(), ".xml", projectileAction.FileName, ToolStack);
            //dataFile.OnSelectedItemChange += (obj, e) =>
            //{
            //	projectileAction.FileName = dataFile.SelectedItem;
            //};

            //add the start offset 
            var startOffset = AddVectorEdit("Start Offset:", projectileAction.StartOffset, ToolStack);
            startOffset.OnVectorEdited += (obj, e) =>
            {
                projectileAction.StartOffset = e.Vector;
            };

            AddActionDirectionControls(projectileAction.Velocity, ToolStack);

            //add a control to change the scale of the projectile
            CreateLabel("scale", ToolStack);
            var scale = CreateNumEditBox(projectileAction.Scale, ToolStack);
            scale.OnNumberEdited += (obj, e) =>
            {
                projectileAction.Scale = scale.Number;
            };
        }

        #endregion //Methods
    }
}
