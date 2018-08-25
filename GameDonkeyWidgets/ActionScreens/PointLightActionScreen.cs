using GameDonkeyLib;
using MenuBuddy;
using Microsoft.Xna.Framework;
using ResolutionBuddy;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameDonkeyWidgets
{
	public class PointLightActionScreen : BaseActionScreen
	{
		#region Properties

		#endregion //Properties

		#region Methods

		public PointLightActionScreen(BaseAction stateAction, PlayerQueue character) : base("Point Light", stateAction, character)
		{
		}

		protected override void AddStateActionWidgets()
		{
			var lightAction = StateAction as PointLightAction;

			//Create the scroll layout...
			var scroller = new ScrollLayout()
			{
				Horizontal = HorizontalAlignment.Left,
				Vertical = VerticalAlignment.Top,
				Size = new Vector2(360f, Resolution.ScreenArea.Height - ToolStack.Rect.Bottom),
				Position = new Point(ToolStack.Rect.Left, ToolStack.Rect.Bottom)
			};

			//Create the scrolling stack and add to the scroller
			var scrollingStack = new StackLayout()
			{
				Alignment = StackAlignment.Top,
				Horizontal = HorizontalAlignment.Left,
				Vertical = VerticalAlignment.Top
			};

			//bone dropdown (with null option)
			var bone = AddBoneDropdown(Character.Character.AnimationContainer, scrollingStack, true, lightAction.Bone);
			bone.OnSelectedItemChange += (obj, e) =>
			{
				lightAction.BoneName = e.SelectedItem != null ? e.SelectedItem.Name : null;
			};

			//start offset
			var startOffset = AddVector3Edit("Start Offset", lightAction.StartOffset, scrollingStack);
			startOffset.OnVector3Edited += (obj, e) =>
			{
				lightAction.StartOffset = e.Vector;
			};

			//start color
			var color = AddColorEdit("Color:", lightAction.LightColor, scrollingStack);
			color.OnColorEdited += (obj, e) =>
			{
				lightAction.LightColor = e.Color;
			};

			CreateLabel("Attack:", scrollingStack);
			var attack = CreateNumEditBox(lightAction.AttackTimeDelta, scrollingStack);
			attack.OnNumberEdited += (obj, e) =>
			{
				lightAction.AttackTimeDelta = e.Num;
			};

			CreateLabel("Sustain:", scrollingStack);
			var sustain = CreateNumEditBox(lightAction.SustainTimeDelta, scrollingStack);
			sustain.OnNumberEdited += (obj, e) =>
			{
				lightAction.SustainTimeDelta = e.Num;
			};

			CreateLabel("Delay:", scrollingStack);
			var delay = CreateNumEditBox(lightAction.DelayTimeDelta, scrollingStack);
			delay.OnNumberEdited += (obj, e) =>
			{
				lightAction.DelayTimeDelta = e.Num;
			};

			CreateLabel("Flare:", scrollingStack);
			var flare = CreateNumEditBox(lightAction.FlareTimeDelta, scrollingStack);
			flare.OnNumberEdited += (obj, e) =>
			{
				lightAction.FlareTimeDelta = e.Num;
			};

			CreateLabel("Min Brightness:", scrollingStack);
			var minbrightness = CreateNumEditBox(lightAction.MinBrightness, scrollingStack);
			minbrightness.OnNumberEdited += (obj, e) =>
			{
				lightAction.MinBrightness = e.Num;
			};

			CreateLabel("Max Brightness:", scrollingStack);
			var maxbrightness = CreateNumEditBox(lightAction.MaxBrightness, scrollingStack);
			maxbrightness.OnNumberEdited += (obj, e) =>
			{
				lightAction.MaxBrightness = e.Num;
			};

			//add the scroller
			scroller.AddItem(scrollingStack);
			AddItem(scroller);
		}

		#endregion //Methods
	}
}
