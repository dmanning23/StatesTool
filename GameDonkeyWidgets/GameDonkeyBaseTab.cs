using AnimationLibWidgets;
using GameDonkeyLib;
using MenuBuddy;
using Microsoft.Xna.Framework;
using StateMachineBuddy;
using System;
using System.Collections.Generic;
using System.Text;
using WidgetLib;

namespace GameDonkeyWidgets
{
	public class GameDonkeyBaseTab : AnimationLibBaseTab
	{
		public GameDonkeyBaseTab(string screenName) : base(screenName)
		{
		}

		protected StateContainerDropdown AddStateContainerDropdown(IStateContainer container, IStackLayout layout)
		{
			layout.AddItem(new Label("State Containers: ", Content, FontSize.Small)
			{
				Horizontal = HorizontalAlignment.Left,
				Vertical = VerticalAlignment.Top,
				TransitionObject = new WipeTransitionObject(TransitionWipeType.PopRight),
				Highlightable = false
			});
			var dropdown = new StateContainerDropdown(this)
			{
				Size = new Vector2(360f, 32f),
				Horizontal = HorizontalAlignment.Left,
				Vertical = VerticalAlignment.Top,
				TransitionObject = new WipeTransitionObject(TransitionWipeType.PopRight),
				HasOutline = true
			};
			dropdown.AddData(container);
			layout.AddItem(dropdown);
			AddShim(layout);

			return dropdown;
		}

		protected StateMessageDropdown AddStateMessageDropdown(StateMachine stateMachine, IStackLayout layout)
		{
			layout.AddItem(new Label("Messages: ", Content, FontSize.Small)
			{
				Horizontal = HorizontalAlignment.Left,
				Vertical = VerticalAlignment.Top,
				TransitionObject = new WipeTransitionObject(TransitionWipeType.PopRight),
				Highlightable = false
			});
			var dropdown = new StateMessageDropdown(stateMachine, this)
			{
				Size = new Vector2(360f, 32f),
				Horizontal = HorizontalAlignment.Left,
				Vertical = VerticalAlignment.Top,
				TransitionObject = new WipeTransitionObject(TransitionWipeType.PopRight),
				HasOutline = true
			};
			layout.AddItem(dropdown);
			AddShim(layout);

			return dropdown;
		}

		protected void AddActionDirectionControls(ActionDirection direction, IStackLayout layout)
		{
			layout.AddItem(new Label("Direction Type: ", Content, FontSize.Small)
			{
				Horizontal = HorizontalAlignment.Left,
				Vertical = VerticalAlignment.Top,
				TransitionObject = new WipeTransitionObject(TransitionWipeType.PopRight),
				Highlightable = false
			});

			var dropdown = new DirectionTypeDropdown(this)
			{
				Size = new Vector2(360f, 32f),
				Horizontal = HorizontalAlignment.Left,
				Vertical = VerticalAlignment.Top,
				TransitionObject = new WipeTransitionObject(TransitionWipeType.PopRight),
				HasOutline = true
			};
			dropdown.SelectedItem = direction.DirectionType;
			dropdown.OnSelectedItemChange += (obj, e) =>
			{
				direction.DirectionType = e.SelectedItem;
			};
			layout.AddItem(dropdown);
			AddShim(layout);

			var vector = AddVectorEdit("Velocity:", direction.Velocity, layout);
			vector.OnVectorEdited += (obj, e) =>
			{
				direction.Velocity = e.Vector;
			};
		}
	}
}
