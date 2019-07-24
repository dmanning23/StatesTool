using AnimationLib;
using BeachBlocksGameDonkey.SharedProject;
using FilenameBuddy;
using FontBuddyLib;
using GameDonkeyLib;
using GrimoireLib;
using HadoukInput;
using LanguageGameDonkey.SharedProject;
using MenuBuddy;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using RenderBuddy;
using ResolutionBuddy;
using RoboJetsDonkeyLib;
using StateMachineBuddy;
using System.Collections.Generic;
using TassleGameLib;
using WeddingGameLib;

namespace StatesTool
{
	/// <summary>
	/// This is the screen that displays the model
	/// </summary>
	public class DonkeyScreen : Screen, IGameScreen
	{
		#region Properties

		private IRenderer Renderer;

		private IGameDonkey Engine;

		/// <summary>
		/// The character we are editing the states for
		/// null until the files get loaded
		/// </summary>
		public PlayerQueue Character { get; set; }

		/// <summary>
		/// Extra state container to add & save out
		/// </summary>
		Dictionary<string, StateMachineActions> StateActions { get; set; }

		FontBuddy _text;

		bool addAllMessages;

		/// <summary>
		/// This is used for getting controller input
		/// </summary>
		InputState _input;

		#endregion //Properties

		#region Methods

		public DonkeyScreen() : base("DonkeyScreen")
		{
			StateActions = new Dictionary<string, StateMachineActions>();
			Layer = -300;
		}

		public override void LoadContent()
		{
			base.LoadContent();

			_text = new FontBuddy();
			_text.LoadContent(Content, @"Fonts\ArialBlack14");

			Renderer = new Renderer(ScreenManager.Game, Content)
			{
				TextureLoader = new TextureFileLoader(),
				AmbientColor = new Color(.2f, .2f, .2f)
			};
			Renderer.ClearLights();
			Renderer.AddDirectionalLight(new Vector3(-.5f, -1f, .6f), new Color(1f, 1f, .75f));
			Renderer.AddDirectionalLight(new Vector3(.5f, -1f, -.1f), new Color(1f, .7f, 0f));
			Renderer.AddDirectionalLight(new Vector3(0f, 1f, .1f), new Color(.2f, 0f, .3f));

			_input = new InputState();

			addAllMessages = false;


			//LoadTree();
			//LoadGoblin();
			//LoadMummy();
			//LoadSkeleton();
			//LoadDragon();
			//LoadHydra();
			//LoadWolf();
			//LoadArcher();
			//LoadKnight();
			//LoadWizard();
			//LoadTassleCarrie();
			//LoadRoboJet();

			//LoadWeddingTabby();
			//LoadWeddingDan();
			//LoadWeddingCarrie();
			LoadWeddingBestMen();

			//LoadRoboJet();

			//LoadGrimoireDan();
			//LoadGrimoireKnight();

			//LoadBeachBlocks();

			ScreenManager.AddScreen(new ToolsScreen(Engine, this));
			ScreenManager.AddScreen(new StateContainersScreen(Engine, Character));
		}

		protected void LoadStateContainer(string containerName, string stateMachineFile, string containerFile)
		{
			var stateMachineFilename = new Filename() { File = stateMachineFile };
			var stateChanges = new StateMachineModel(stateMachineFilename);
			stateChanges.ReadXmlFile();
	
			var containerFilename = new Filename() { File = containerFile };
			var stateActions = new StateMachineActions();
			var stateContainer = new SingleStateContainerModel(containerFilename);
			stateContainer.ReadXmlFile();
			stateActions.LoadStateActions(stateChanges.StateNames, stateContainer, Character.Character, Character.Character.States);

			stateActions.LoadContent(Engine, Content);

			foreach (var characterStateContainer in Character.Character.States.StateContainers)
			{
				characterStateContainer.Actions.AddStateMachineActions(stateActions);
			}
			StateActions[containerFile] = stateActions;
		}

		public void Save()
		{
			foreach (var stateContainer in StateActions)
			{
				var filename = new Filename() { File = stateContainer.Key };
				var single = new SingleStateContainerModel(filename, stateContainer.Value);
				single.WriteXml();
				foreach (var characterStateContainer in Character.Character.States.StateContainers)
				{
					characterStateContainer.Actions.RemoveStateMachineActions(stateContainer.Value);
				}
			}

			Character.Character.States.WriteXml(addAllMessages);

			foreach (var stateContainer in StateActions)
			{
				foreach (var characterStateContainer in Character.Character.States.StateContainers)
				{
					characterStateContainer.Actions.AddStateMachineActions(stateContainer.Value);
				}
			}
		}

		/// <summary>
		/// Set the world, camera boundaries to match the window
		/// </summary>
		private void SetWorldBoundaries()
		{
			if (null != Engine)
			{
				Engine.WorldBoundaries = new Rectangle(Resolution.ScreenArea.X, 
					Resolution.ScreenArea.Y, 
					Resolution.ScreenArea.Width, 
					Resolution.ScreenArea.Height * 5);
				Engine.Renderer.Camera.IgnoreWorldBoundary = true;

				Engine.SpawnPoints = new List<Vector2> { new Vector2(-1000f,1000f) };
			}
		}

		public override void Update(GameTime gameTime, bool otherWindowHasFocus, bool covered)
		{
			base.Update(gameTime, otherWindowHasFocus, covered);

			if (null != Engine)
			{
				Engine.Update(gameTime);

				for (int i = 0; i < Engine.Players.Count; i++)
				{
					Engine.Players[i].GetPlayerInput(Engine.Players, false);

					//check hard coded states for all players, but only on the server
					Engine.Players[i].CheckHardCodedStates();
				}
			}
		}

		public override void Draw(GameTime gameTime)
		{
			base.Draw(gameTime);

			//add the center point to the camera to anchor the screen
			Renderer.Camera.AddPoint(new Vector2(Character.Character.Position.X, Character.Character.Position.Y - 400));

			//update the camera
			Engine.UpdateCameraMatrix();

			//draw the game
			Engine.Render(BlendState.NonPremultiplied);

			//draw the current time at the top of the screen
			Renderer.SpriteBatchBeginNoEffect(BlendState.AlphaBlend, Resolution.TransformationMatrix(), SpriteSortMode.Texture);

			var position = new Point(Resolution.TitleSafeArea.Center.X, Resolution.ScreenArea.Top);

			_text.Write(string.Format("state clock: {0:0.00}", Character.Character.States.StateClock.CurrentTime),
				position,
				Justify.Center,
				1f,
				Color.White,
				Renderer.SpriteBatch,
				Character.CharacterClock);
			position.Y += _text.Font.LineSpacing;

			_text.Write(string.Format("current state: {0}", Character.Character.States.CurrentState),
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

		public void HandleInput(InputState input)
		{
			_input.Update();
			Engine.UpdateInput(_input);
		}

		#endregion //Methods

		#region Load Stuff

		private Garment LoadGarment(string garmentFile, PlayerQueue player)
		{
			if (!string.IsNullOrEmpty(garmentFile))
			{
				var filename = new Filename();
				filename.File = garmentFile;

				var garment = new Garment(filename, player.Character.AnimationContainer.Skeleton, Renderer);
				garment.AddToSkeleton();

				return garment;
			}

			return null;
		}

		#region Language Warriors

		private void LoadArcher()
		{
			LoadLanguageMonster(@"C:\Projects\languagegame\LanguageGame.SharedProject\Content\Monsters\Archer\Archer_Data.xml");
		}

		private void LoadKnight()
		{
			LoadLanguageMonster(@"C:\Projects\languagegame\LanguageGame.SharedProject\Content\Monsters\Knight\Knight_Data.xml");
		}

		private void LoadTree()
		{
			LoadLanguageMonster(@"C:\Projects\languagegame\LanguageGame.SharedProject\Content\Monsters\Tree\Tree_Data.xml");
		}

		private void LoadGoblin()
		{
			LoadLanguageMonster(@"C:\Projects\languagegame\LanguageGame.SharedProject\Content\Monsters\Goblin\Goblin_Data.xml");
		}

		private void LoadMummy()
		{
			LoadLanguageMonster(@"C:\Projects\languagegame\LanguageGame.SharedProject\Content\Monsters\Mummy\Mummy_Data.xml");
		}

		private void LoadSkeleton()
		{
			LoadLanguageMonster(@"C:\Projects\languagegame\LanguageGame.SharedProject\Content\Monsters\Skeleton\Skeleton_Data.xml");
		}

		private void LoadDragon()
		{
			LoadLanguageMonster(@"C:\Projects\languagegame\LanguageGame.SharedProject\Content\Monsters\Dragon\Dragon_Data.xml");
		}

		private void LoadHydra()
		{
			LoadLanguageMonster(@"C:\Projects\languagegame\LanguageGame.SharedProject\Content\Monsters\Hydra\Hydra_Data.xml");
		}

		private void LoadWolf()
		{
			LoadLanguageMonster(@"C:\Projects\languagegame\LanguageGame.SharedProject\Content\Monsters\Wolf\Wolf_Data.xml");
		}

		private void LoadWizard()
		{
			LoadLanguageMonster(@"C:\Projects\languagegame\LanguageGame.SharedProject\Content\Monsters\Wizard\Wizard_Data.xml", true);
		}

		private void LoadLanguageMonster(string resource, bool setColor = false)
		{
			//create the correct engine
			Filename.SetCurrentDirectory(@"C:\Projects\languagegame\LanguageGame.SharedProject\Content\");
			Engine = new LanguageDonkey(Renderer, ScreenManager.Game);
			Engine.LoadContent(ScreenManager.Game.GraphicsDevice, null);
			SetWorldBoundaries();

			//load the file
			var dataFile = new Filename
			{
				File = resource
			};
			Character = Engine.LoadPlayer(setColor ? new Color(55, 155, 240) : Color.White, dataFile, PlayerIndex.One, "Catpants");
			Character.Character.Flip = false;
			Engine.Start();
		}

		#endregion //Language Warriors

		#region RoboJets

		private void LoadRoboJet()
		{
			//create the correct engine
			Filename.SetCurrentDirectory(@"C:\Projects\robojets\RoboJets\RoboJets.SharedProject\Content\");
			Engine = new RoboJetsDonkey(Renderer, ScreenManager.Game)
			{
				ToolMode = true,
			};
			Engine.LoadContent(ScreenManager.Game.GraphicsDevice, null);
			SetWorldBoundaries();

			//load the file
			var dataFile = new Filename
			{
				File = @"C:\Projects\robojets\RoboJets\RoboJets.SharedProject\Content\Robot\RobotData.xml"
			};
			Character = Engine.LoadPlayer(Color.White, dataFile, PlayerIndex.One, "Catpants");
			Engine.Start();
		}

		#endregion //RoboJets

		#region Wedding

		private void LoadWeddingTabby()
		{
			LoadWedding(@"C:\Projects\weddinggame\WeddingGame.SharedProject\Content\Tabby\TabbyData.xml");
		}

		private void LoadWeddingDan()
		{
			LoadWedding(@"C:\Projects\weddinggame\WeddingGame.SharedProject\Content\Dan\DanData.xml");
		}

		private void LoadWeddingCarrie()
		{
			LoadWedding(@"C:\Projects\weddinggame\WeddingGame.SharedProject\Content\Carrie\CarrieData.xml");
		}

		private void LoadWeddingBestMen()
		{
			LoadWedding(@"C:\Projects\weddinggame\WeddingGame.SharedProject\Content\BestMen\BestMenData.xml");
		}

		private void LoadWedding(string dataFilename)
		{
			//create the correct engine
			Filename.SetCurrentDirectory(@"C:\Projects\weddinggame\WeddingGame.SharedProject\Content\");
			Engine = new WeddingDonkey(Renderer, ScreenManager.Game)
			{
				ToolMode = true
			};
			Engine.LoadContent(ScreenManager.Game.GraphicsDevice, null);

			//SetWorldBoundaries();
			Engine.LoadBoard(new Filename(@"WeddingVenue\WeddingVenueBoard.xml"));

			//load the file
			var dataFile = new Filename
			{
				File = dataFilename
			};
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
			Engine.LoadContent(ScreenManager.Game.GraphicsDevice, null);
			SetWorldBoundaries();

			//load the file
			var dataFile = new Filename
			{
				File = @"C:\Projects\tasslegame\Windows\Content\Carrie\carrie data.xml"
			};
			Character = Engine.LoadPlayer(Color.White, dataFile, PlayerIndex.One, "Catpants");
			Engine.Start();
		}

		#endregion //Tassle

		#region Grimoire

		private void LoadGrimoireKnight()
		{
			LoadGrimoire(@"C:\Projects\Grimoire\Grimoire.SharedProject\Content\Spells\Knight\Knight_Data.xml");
		}

		private void LoadGrimoireDan()
		{
			LoadGrimoire(@"C:\Projects\Grimoire\Grimoire.SharedProject\Content\Dan\Dan_Data.xml");
			LoadStateContainer("Sword", 
				@"C:\Projects\Grimoire\Grimoire.SharedProject\Content\Spells\Sword\Slash_StateMachine.xml",
				@"C:\Projects\Grimoire\Grimoire.SharedProject\Content\Spells\Sword\Slash_States.xml");
			LoadStateContainer("Shield",
				@"C:\Projects\Grimoire\Grimoire.SharedProject\Content\Spells\Shield\Block_StateMachine.xml",
				@"C:\Projects\Grimoire\Grimoire.SharedProject\Content\Spells\Shield\Block_States.xml");
			LoadStateContainer("Broom",
				@"C:\Projects\Grimoire\Grimoire.SharedProject\Content\Spells\Broom\Dash_StateMachine.xml",
				@"C:\Projects\Grimoire\Grimoire.SharedProject\Content\Spells\Broom\Dash_States.xml");

		}

		private void LoadGrimoire(string dataFilename)
		{
			//create the correct engine
			Filename.SetCurrentDirectory(@"C:\Projects\Grimoire\Grimoire.SharedProject\Content\");
			Engine = new GrimoireDonkey(Renderer, ScreenManager.Game)
			{
				ToolMode = true
			};
			Engine.LoadContent(ScreenManager.Game.GraphicsDevice, null);
			SetWorldBoundaries();

			//load the file
			var dataFile = new Filename
			{
				File = dataFilename
			};
			Character = Engine.LoadPlayer(Color.White, dataFile, PlayerIndex.One, "Catpants");
			Engine.Start();
		}

		#endregion //Grimoire

		#region Beach Blocks

		private void LoadBeachBlocks()
		{
			//create the correct engine
			Filename.SetCurrentDirectory(@"C:\Projects\opposites.mobile\Opposites.SharedProject\Content\");
			Engine = new BeachBlocksDonkey(Renderer, ScreenManager.Game);
			Engine.LoadContent(ScreenManager.Game.GraphicsDevice, null);
			SetWorldBoundaries();

			//load the file
			var dataFile = new Filename
			{
				File = @"C:\Projects\opposites.mobile\Opposites.SharedProject\Content\Character\Character_Data.xml"
			};
			Character = Engine.LoadPlayer(Color.White, dataFile, PlayerIndex.One, "Catpants");

			var garmentFile = new Filename();
			garmentFile.SetFilenameRelativeToPath(dataFile, @"Clothes\Eye\GreenEyes.xml");
			LoadGarment(garmentFile.File, Character);
			garmentFile.SetFilenameRelativeToPath(dataFile, @"Clothes\Bikini\RedBikini.xml");
			LoadGarment(garmentFile.File, Character);
			garmentFile.SetFilenameRelativeToPath(dataFile, @"Hair\PixieCut\PixieCut.xml");
			LoadGarment(garmentFile.File, Character);

			Character.Character.AnimationContainer.SetColor("skin", new Color(255, 210, 210));
			Character.Character.AnimationContainer.SetColor("lips", Color.HotPink);
			Character.Character.AnimationContainer.SetColor("lashes", new Color(40, 30, 20));
			Character.Character.AnimationContainer.SetColor("eyebrows", new Color(140, 110, 40));
			Character.Character.AnimationContainer.SetColor("hair", new Color(230, 230, 130));
			Character.Character.AnimationContainer.SetColor("tetrad", new Color(0, 0, 128));

			Engine.Start();
		}

		#endregion //Beach Blocks

		#endregion //Load Stuff
	}
}
