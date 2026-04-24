using GameDonkeyLib;
using MenuBuddy;
using System.Threading.Tasks;

namespace StatesTool
{
    public class StateContainersScreen : GameDonkeyBaseTab
    {
        #region Properties

        IGameDonkey Engine { get; set; }
        IPlayerQueue Character { get; set; }

        #endregion //Properties

        #region Methods

        public StateContainersScreen(IGameDonkey donkey, IPlayerQueue character) : base("StateContainers")
        {
            CoveredByOtherScreens = true;
            CoverOtherScreens = true;

            Engine = donkey;
            Character = character;

            Layer = -200;
        }

        public override async Task LoadContent()
        {
            await base.LoadContent();

            if (null != Character.Character.States)
            {
                await ScreenManager.AddScreen(new StatesScreen(Engine, Character, Character.Character.States));
            }
        }

        #endregion //Methods
    }
}
