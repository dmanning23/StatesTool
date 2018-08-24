using GameDonkeyLib;
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

			//bone dropdown (with null option)
			var bone = AddBoneDropdown(Character.Character.AnimationContainer, ToolStack, true);
			bone.OnSelectedItemChange += (obj, e) =>
			{
				lightAction.BoneName = e.SelectedItem != null ? e.SelectedItem.Name : null;
			};

			//start offset
			var startOffset = AddVector3Edit("Start Offset", lightAction.StartOffset, ToolStack);
			startOffset.OnVector3Edited += (obj, e) =>
			{
				lightAction.StartOffset = e.Vector;
			};

			//start color
			var color = AddColorEdit("Color:", lightAction.LightColor, ToolStack);
			color.OnColorEdited += (obj, e) =>
			{
				lightAction.LightColor = e.Color;
			};

			CreateLabel("Attack:", ToolStack);
			var attack = CreateNumEditBox(lightAction.AttackTimeDelta, ToolStack);
			attack.OnNumberEdited += (obj, e) =>
			{
				lightAction.AttackTimeDelta = e.Num;
			};

			CreateLabel("Sustain:", ToolStack);
			var sustain = CreateNumEditBox(lightAction.SustainTimeDelta, ToolStack);
			sustain.OnNumberEdited += (obj, e) =>
			{
				lightAction.SustainTimeDelta = e.Num;
			};

			CreateLabel("Delay:", ToolStack);
			var delay = CreateNumEditBox(lightAction.DelayTimeDelta, ToolStack);
			delay.OnNumberEdited += (obj, e) =>
			{
				lightAction.DelayTimeDelta = e.Num;
			};

			CreateLabel("Flare:", ToolStack);
			var flare = CreateNumEditBox(lightAction.FlareTimeDelta, ToolStack);
			flare.OnNumberEdited += (obj, e) =>
			{
				lightAction.FlareTimeDelta = e.Num;
			};

			CreateLabel("Min Brightness:", ToolStack);
			var minbrightness = CreateNumEditBox(lightAction.MinBrightness, ToolStack);
			minbrightness.OnNumberEdited += (obj, e) =>
			{
				lightAction.MinBrightness = e.Num;
			};

			CreateLabel("Max Brightness:", ToolStack);
			var maxbrightness = CreateNumEditBox(lightAction.MaxBrightness, ToolStack);
			maxbrightness.OnNumberEdited += (obj, e) =>
			{
				lightAction.MaxBrightness = e.Num;
			};
		}

		#endregion //Methods
	}
}
