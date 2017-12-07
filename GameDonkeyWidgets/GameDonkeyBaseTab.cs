using AnimationLibWidgets;
using GameDonkeyLib;
using MenuBuddy;
using Microsoft.Xna.Framework;
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
			layout.AddItem(new Label("State Containers: ", FontSize.Small)
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
	}
}
