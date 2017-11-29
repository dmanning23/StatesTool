using GameDonkeyLib;
using InputHelper;
using MenuBuddy;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ResolutionBuddy;
using System.Collections.Generic;
using Image = MenuBuddy.Image;

namespace StatesTool
{
	/// <summary>
	/// This is a widget screen with items like undo, redo, save, the tab buttons, etc.
	/// </summary>
	public class ToolsScreen : WidgetScreen
	{
		#region Properties

		IGameDonkey Engine { get; set; }
		PlayerQueue Character { get; set; }

		#endregion //Properties

		#region Methods

		public ToolsScreen(IGameDonkey donkey, PlayerQueue character) : base("ToolsScreen")
		{
			CoveredByOtherScreens = false;
			CoverOtherScreens = false;

			Engine = donkey;
			Character = character;
		}

		public override void LoadContent()
		{
			base.LoadContent();

			AddAsMenuItems();
		}

		private void AddAsMenuItems()
		{
			var stack = new StackLayout()
			{
				Alignment = StackAlignment.Top,
				Position = new Point(Resolution.ScreenArea.Left, 0),
				Horizontal = HorizontalAlignment.Left,
				Vertical = VerticalAlignment.Top,
			};

			var hamburgerItems = new List<ContextMenuItem>();
			hamburgerItems.Add(new ContextMenuItem(ScreenManager.Game.Content.Load<Texture2D>(@"icons\save"), "Save", Save));
			hamburgerItems.Add(new ContextMenuItem(ScreenManager.Game.Content.Load<Texture2D>(@"icons\undo"), "Reset", Reset));

			//add each menu item below this
			foreach (var hamburgerItem in hamburgerItems)
			{
				CreateButton(hamburgerItem, stack);
			}

			AddItem(stack);
		}

		private void CreateButton(ContextMenuItem hamburgerItem, StackLayout stack)
		{
			var button = new StackLayoutButton()
			{
				Vertical = VerticalAlignment.Center,
				Horizontal = HorizontalAlignment.Left,
				TransitionObject = new WipeTransitionObject(TransitionWipeType.PopLeft),
				Alignment =StackAlignment.Left,
			};
			button.AddItem(new Image(hamburgerItem.Icon)
			{
				Size = new Vector2(32f, 32f),
				Vertical = VerticalAlignment.Center,
				Horizontal = HorizontalAlignment.Left,
				FillRect = true,
				TransitionObject = new WipeTransitionObject(TransitionWipeType.PopLeft)
			});
			button.AddItem(new Shim()
			{
				Size = new Vector2(16f, 16f)
			});
			button.AddItem(new Label(hamburgerItem.IconText, FontSize.Small)
			{
				Vertical = VerticalAlignment.Top,
				Horizontal = HorizontalAlignment.Left,
				TransitionObject = new WipeTransitionObject(TransitionWipeType.PopLeft)
			});
			button.OnClick += (obj, e) => hamburgerItem.ClickEvent(obj, e);

			stack.AddItem(button);
			stack.AddItem(new Shim()
			{
				Size = new Vector2(8f, 8f)
			});
		}

		#endregion //Methods

		#region Hamburger Event Handlers

		private void Save(object obj, ClickEventArgs e)
		{
			Character.Character.States.WriteXml();
		}

		private void Reset(object obj, ClickEventArgs e)
		{
			Engine.RespawnPlayer(Character);
		}

		#endregion //Hamburger Event Handlers
	}
}
