using FilenameBuddy;
using FontBuddyLib;
using GameDonkeyLib;
using LanguageGameDonkey.SharedProject;
using MenuBuddy;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using RenderBuddy;
using ResolutionBuddy;
using RoboJetsLib;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TassleGameLib;
using WeddingGameLib;

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

		FontBuddy _text;

		#endregion //Properties

		#region Methods

		public DonkeyScreen() : base("DonkeyScreen")
		{
		}

		public override void LoadContent()
		{
			base.LoadContent();

			_text = new FontBuddy();
			_text.LoadContent(Content, @"Fonts\ArialBlack14");

			Renderer = new Renderer(ScreenManager.Game, Content);
			Renderer.TextureLoader = new TextureFileLoader();
			Renderer.AmbientColor = new Color(.2f, .2f, .2f);
			Renderer.ClearLights();
			Renderer.AddDirectionalLight(new Vector3(.5f, -1f, .6f), new Color(1f, 1f, .75f));
			Renderer.AddDirectionalLight(new Vector3(-.5f, -1f, -.1f), new Color(1f, .7f, 0f));
			Renderer.AddDirectionalLight(new Vector3(0f, 1f, .1f), new Color(.2f, 0f, .3f));

			//LoadTree();
			//LoadGoblin();
			//LoadArcher();
			//LoadTassleCarrie();
			//LoadRoboJet();
			LoadWeddingTabby();
			//LoadWeddingDan();
			//LoadWeddingCarrie();
			//LoadWeddingBestMen();

			ScreenManager.AddScreen(new ToolsScreen(Engine, Character));
			ScreenManager.AddScreen(new StateContainersScreen(Engine, Character));
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

			//add the center point to the camera to anchor the screen
			Renderer.Camera.AddPoint(Resolution.ScreenArea.Center.ToVector2());

			//update the camera
			Engine.UpdateCameraMatrix();

			//draw the game
			Engine.Render(BlendState.AlphaBlend);

			//draw the current time at the top of the screen
			Renderer.SpriteBatchBegin(BlendState.AlphaBlend, Resolution.TransformationMatrix(), SpriteSortMode.Texture);

			var position = new Point(Resolution.TitleSafeArea.Center.X, Resolution.ScreenArea.Top);

			_text.Write(string.Format("state clock: {0:0.00}", Character.Character.States.StateClock.CurrentTime),
				position,
				Justify.Center,
				1f,
				Color.White,
				Renderer.SpriteBatch,
				Character.CharacterClock);
			position.Y += _text.Font.LineSpacing;

			_text.Write(string.Format("current state: {0}", Character.Character.States.CurrentStateText),
				position,
				Justify.Center,
				1f,
				Color.White,
				Renderer.SpriteBatch,
				Character.CharacterClock);
			position.Y += _text.Font.LineSpacing;

			if (null != Character.Character.AnimationContainer.CurrentAnimation)
			{
				_text.Write(string.Format("animation: {0}", Character.Character.AnimationContainer.CurrentAnimation.Name),
					position,
					Justify.Center,
					1f,
					Color.White,
					Renderer.SpriteBatch,
					Character.CharacterClock);
				position.Y += _text.Font.LineSpacing;
			}

			Renderer.SpriteBatchEnd();
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

		#region Load Stuff

		#region Language Warriors

		private void LoadArcher()
		{
			LoadLanguageMonster(@"C:\Projects\languagegame\LanguageGame.SharedProject\Content\Monsters\Archer\Archer_Data.xml");
		}

		private void LoadTree()
		{
			LoadLanguageMonster(@"C:\Projects\languagegame\LanguageGame.SharedProject\Content\Monsters\Tree\Tree_Data.xml");
		}

		private void LoadGoblin()
		{
			LoadLanguageMonster(@"C:\Projects\languagegame\LanguageGame.SharedProject\Content\Monsters\Goblin\Goblin_Data.xml");
		}

		private void LoadLanguageMonster(string resource)
		{
			//create the correct engine
			Filename.SetCurrentDirectory(@"C:\Projects\languagegame\LanguageGame.SharedProject\Content\");
			Engine = new LanguageDonkey(Renderer, ScreenManager.Game);
			Engine.LoadContent(ScreenManager.Game.GraphicsDevice);
			SetWorldBoundaries();

			//load the file
			var dataFile = new Filename();
			dataFile.File = resource;
			Character = Engine.LoadPlayer(Color.White, dataFile, PlayerIndex.One, "Catpants");
			Engine.Start();
		}

		#endregion //Language Warriors

		#region RoboJets

		private void LoadRoboJet()
		{
			//create the correct engine
			Filename.SetCurrentDirectory(@"C:\Projects\robojets\Source\Content\");
			Engine = new RoboJetsDonkey(Renderer, null);
			Engine.LoadContent(ScreenManager.Game.GraphicsDevice);
			SetWorldBoundaries();

			//load the file
			var dataFile = new Filename();
			dataFile.File = @"C:\Projects\robojets\Source\Content\Robot\Robot Data.xml";
			Character = Engine.LoadPlayer(Color.White, dataFile, PlayerIndex.One, "Catpants");
			Engine.Start();
		}

		#endregion //RoboJets

		#region Wedding

		private void LoadWeddingTabby()
		{
			LoadWedding(@"C:\Projects\weddinggame\WeddingGame.SharedProject\Content\Tabby\Tabby data.xml");
		}

		private void LoadWeddingDan()
		{
			LoadWedding(@"C:\Projects\weddinggame\WeddingGame.SharedProject\Content\Dan\Dan data.xml");
		}

		private void LoadWeddingCarrie()
		{
			LoadWedding(@"C:\Projects\weddinggame\WeddingGame.SharedProject\Content\Carrie\Carrie data.xml");
		}

		private void LoadWeddingBestMen()
		{
			LoadWedding(@"C:\Projects\weddinggame\WeddingGame.SharedProject\Content\BestMen\BestMen data.xml");
		}

		private void LoadWedding(string dataFilename)
		{
			//create the correct engine
			Filename.SetCurrentDirectory(@"C:\Projects\weddinggame\WeddingGame.SharedProject\Content\");
			Engine = new WeddingDonkey(Renderer, ScreenManager.Game);
			Engine.LoadContent(ScreenManager.Game.GraphicsDevice);
			SetWorldBoundaries();

			//load the file
			var dataFile = new Filename();
			//dataFile.File = ;
			dataFile.File = dataFilename;
			Character = Engine.LoadPlayer(Color.White, dataFile, PlayerIndex.One, "Catpants");
			Engine.Start();
		}

		#endregion //Wedding

		#region Tassle

		private void LoadTassleCarrie()
		{
			//create the correct engine
			Filename.SetCurrentDirectory(@"C:\Projects\tasslegame\Windows\Content\");
			Engine = new TassleDonkey(Renderer, ScreenManager.Game);
			Engine.LoadContent(ScreenManager.Game.GraphicsDevice);
			SetWorldBoundaries();

			//load the file
			var dataFile = new Filename();
			dataFile.File = @"C:\Projects\tasslegame\Windows\Content\Carrie\carrie data.xml";
			Character = Engine.LoadPlayer(Color.White, dataFile, PlayerIndex.One, "Catpants");
			Engine.Start();
		}

		#endregion //Tassle

		#endregion //Load Stuff
	}
}
