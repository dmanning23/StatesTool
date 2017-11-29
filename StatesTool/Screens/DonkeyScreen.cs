using FilenameBuddy;
using GameDonkeyLib;
using LanguageGameDonkey.SharedProject;
using MenuBuddy;
using Microsoft.Xna.Framework;
using RenderBuddy;
using ResolutionBuddy;
using System.Collections.Generic;
using TassleGameLib;

namespace StatesTool
{
	/// <summary>
	/// This is the screen that displays the model
	/// </summary>
	public class DonkeyScreen : Screen
	{
		#region Properties

		private IRenderer Renderer;

		private IGameDonkey Engine;

		/// <summary>
		/// The character we are editing the states for
		/// null until the files get loaded
		/// </summary>
		private PlayerQueue Character;

		#endregion //Properties

		#region Methods

		public DonkeyScreen() : base("DonkeyScreen")
		{
		}

		public override void LoadContent()
		{
			base.LoadContent();

			Renderer = new Renderer(ScreenManager.Game, Content);

			//LoadArcher();
			LoadCarrie();

			ScreenManager.AddScreen(new ToolsScreen(Engine, Character));
		}

		private void LoadArcher()
		{
			//create the correct engine
			Engine = new LanguageDonkey(Renderer, ScreenManager.Game);
			Engine.LoadContent(ScreenManager.Game.GraphicsDevice);
			Engine.Renderer.TextureLoader = new TextureFileLoader();
			SetWorldBoundaries();

			//load the file
			Filename.SetCurrentDirectory(@"C:\Projects\languagegame\LanguageGame.SharedProject\Content\");
			Filename dataFile = new Filename();
			dataFile.File = @"C:\Projects\languagegame\LanguageGame.SharedProject\Content\Monsters\Archer\Archer_Data.xml";
			Character = Engine.LoadPlayer(Color.White, dataFile, PlayerIndex.One, "Catpants");
			Engine.Start();
		}

		private void LoadCarrie()
		{
			//create the correct engine
			Engine = new TassleDonkey(Renderer, ScreenManager.Game);
			Engine.LoadContent(ScreenManager.Game.GraphicsDevice);
			Engine.Renderer.TextureLoader = new TextureFileLoader();
			SetWorldBoundaries();

			//load the file
			Filename.SetCurrentDirectory(@"C:\Projects\tasslegame\Windows\Content\");
			Filename dataFile = new Filename();
			dataFile.File = @"C:\Projects\tasslegame\Windows\Content\Carrie\carrie data.xml";
			Character = Engine.LoadPlayer(Color.White, dataFile, PlayerIndex.One, "Catpants");
			Engine.Start();
		}

		/// <summary>
		/// Set the world, camera boundaries to match the window
		/// </summary>
		private void SetWorldBoundaries()
		{
			if (null != Engine)
			{
				Engine.WorldBoundaries = Resolution.ScreenArea;
				Engine.SpawnPoints = new List<Vector2> { Resolution.ScreenArea.Center.ToVector2() };
			}
		}

		public override void Update(GameTime gameTime, bool otherWindowHasFocus, bool covered)
		{
			base.Update(gameTime, otherWindowHasFocus, covered);
			
			if (null != Engine)
			{
				Engine.Update(gameTime);
			}
		}

		public override void Draw(GameTime gameTime)
		{
			base.Draw(gameTime);

			//update the camera
			Engine.UpdateCameraMatrix();

			//draw the game
			Engine.Render();
		}

		public void ClockSpeed(float timeScale)
		{
			if (null != Engine)
			{
				Engine.SetClockSpeed(timeScale);
			}
		}

		public void ResetPlayer()
		{
			if (null != Engine)
			{
				Engine.RespawnPlayer(Character);
			}
		}

		#endregion //Methods
	}
}
