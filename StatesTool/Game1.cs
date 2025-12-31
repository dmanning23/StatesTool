//using AnimationTool.Screens;
using InputHelper;
using MenuBuddy;
using Microsoft.Xna.Framework;

namespace StatesTool
{
	/// <summary>
	/// This is the main type for your game
	/// </summary>
	//public class Game1 : ControllerGame

#if __IOS__ || ANDROID || WINDOWS_UAP
	public class Game1 : TouchGame
#else
	public class Game1 : MouseGame
#endif
	{
		#region Properties

		//AnimationManager AnimationManager { get; set; }

		#endregion //Properties

		#region Methods

		public Game1()
		{
			IsMouseVisible = true;

			//Graphics.SupportedOrientations = DisplayOrientation.Portrait | DisplayOrientation.PortraitDown;
			//VirtualResolution = new Point(720, 1280);
			//ScreenResolution = new Point(720, 1280);
		}

		protected override void LoadContent()
		{
			base.LoadContent();
		}

		protected override void Initialize()
		{
			//AnimationManager.LoadContent();
			base.Initialize();
		}

		protected override void InitStyles()
		{
			StyleSheet.SmallFontResource = @"Fonts\ArialBlack10";
			StyleSheet.ClickedSoundResource = string.Empty;
			StyleSheet.HighlightedSoundResource = string.Empty;
			base.InitStyles();

			//DefaultStyles.Instance().MainStyle.HasOutline = true;
			//DefaultStyles.Instance().MenuEntryStyle.HasOutline = true;
			//DefaultStyles.Instance().MenuTitleStyle.HasOutline = true;
			//DefaultStyles.Instance().MessageBoxStyle.HasOutline = true;
		}

		/// <summary>
		/// Get the set of screens needed for the main menu
		/// </summary>
		/// <returns>The gameplay screen stack.</returns>
		public override IScreen[] GetMainMenuScreenStack()
		{
			return new IScreen[] { new DonkeyScreen() };
		}

		#endregion //Methods
	}
}
