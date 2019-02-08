using GameDonkeyLib;
using MenuBuddy;
using Microsoft.Xna.Framework;
using ResolutionBuddy;

namespace GameDonkeyWidgets
{
	public class ParticleEffectActionScreen : BaseActionScreen
	{
		#region Properties

		#endregion //Properties

		#region Methods

		public ParticleEffectActionScreen(BaseAction stateAction, PlayerQueue character) : base("Particle Effect", stateAction, character)
		{
		}

		protected override void AddStateActionWidgets()
		{
			var particleAction = StateAction as ParticleEffectAction;

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
			var bone = AddBoneDropdown(Character.Character.AnimationContainer, scrollingStack, true, particleAction.Bone);
			bone.OnSelectedItemChange += (obj, e) =>
			{
				particleAction.BoneName = e.SelectedItem != null ? e.SelectedItem.Name : null;
			};

			//velocity vector
			var velocity = AddVectorEdit("Velocity", particleAction.Velocity.Velocity, scrollingStack);
			velocity.OnVectorEdited += (obj, e) =>
			{
				particleAction.Velocity.Velocity = e.Vector;
			};

			//start offset
			var startOffset = AddVectorEdit("Start Offset", particleAction.StartOffset, scrollingStack);
			startOffset.OnVectorEdited += (obj, e) =>
			{
				particleAction.StartOffset = e.Vector;
			};

			//use bone rotation (checkbox)
			var boneRotation = AddCheckbox("Bone Rotation: ", particleAction.UseBoneRotation, scrollingStack);
			boneRotation.OnClick += (obj, e) =>
			{
				particleAction.UseBoneRotation = boneRotation.IsChecked;
			};


			//particle:

			//creation period (float)
			CreateLabel("Creation Period", scrollingStack);
			var creationPeriod = CreateNumEditBox(particleAction.Emitter.CreationPeriod, scrollingStack);
			creationPeriod.OnNumberEdited += (obj, e) =>
			{
				particleAction.Emitter.CreationPeriod = creationPeriod.Number;
			};

			//emitter life (float)
			CreateLabel("Emitter Life", scrollingStack);
			var emitterLife = CreateNumEditBox(particleAction.Emitter.EmitterLife, scrollingStack);
			emitterLife.OnNumberEdited += (obj, e) =>
			{
				particleAction.Emitter.EmitterLife = emitterLife.Number;
			};

			//expires (bool)
			var expires = AddCheckbox("Expires: ", particleAction.Emitter.Expires, scrollingStack);
			expires.OnClick += (obj, e) =>
			{
				particleAction.Emitter.Expires = expires.IsChecked;
			};

			//fade speed (float)
			CreateLabel("Fade Speed", scrollingStack);
			var fadeSpeed = CreateNumEditBox(particleAction.Emitter.FadeSpeed, scrollingStack);
			fadeSpeed.OnNumberEdited += (obj, e) =>
			{
				particleAction.Emitter.FadeSpeed = fadeSpeed.Number;
			};

			//content image
			var content = AddContentFileDropdown("Particle Image", "Particles", ".png", particleAction.Emitter.ImageFile, scrollingStack);
			content.OnSelectedItemChange += (obj, e) =>
			{
				particleAction.Emitter.ImageFile = e.SelectedItem;
				particleAction.Emitter.LoadContent(Engine.Renderer);
			};

			//start rotation: 

			//start rotation min (float)
			CreateLabel("start rotation min", scrollingStack);
			var startRotationMin = CreateNumEditBox(particleAction.Emitter.MinStartRotation, scrollingStack);
			startRotationMin.OnNumberEdited += (obj, e) =>
			{
				particleAction.Emitter.MinStartRotation = startRotationMin.Number;
			};

			//start rotation max (float)
			CreateLabel("start rotation max", scrollingStack);
			var startRotationMax = CreateNumEditBox(particleAction.Emitter.MaxStartRotation, scrollingStack);
			startRotationMax.OnNumberEdited += (obj, e) =>
			{
				particleAction.Emitter.MaxStartRotation = startRotationMax.Number;
			};

			//spin:

			//min spin (float)
			CreateLabel("min spin", scrollingStack);
			var minSpin = CreateNumEditBox(particleAction.Emitter.MinSpin, scrollingStack);
			minSpin.OnNumberEdited += (obj, e) =>
			{
				particleAction.Emitter.MinSpin = minSpin.Number;
			};

			//max spin (float)
			CreateLabel("max spin", scrollingStack);
			var maxSpin = CreateNumEditBox(particleAction.Emitter.MaxSpin, scrollingStack);
			maxSpin.OnNumberEdited += (obj, e) =>
			{
				particleAction.Emitter.MaxSpin = maxSpin.Number;
			};

			//scale:

			//min scale (float)
			CreateLabel("min scale", scrollingStack);
			var minScale = CreateNumEditBox(particleAction.Emitter.MinScale, scrollingStack);
			minScale.OnNumberEdited += (obj, e) =>
			{
				particleAction.Emitter.MinScale = minScale.Number;
			};

			//max sclae (float)
			CreateLabel("max scale", scrollingStack);
			var maxScale = CreateNumEditBox(particleAction.Emitter.MaxScale, scrollingStack);
			maxScale.OnNumberEdited += (obj, e) =>
			{
				particleAction.Emitter.MaxScale = maxScale.Number;
			};

			//velocity:

			//min velocity (vector)
			var minVelocity = AddVectorEdit("min velocity", particleAction.Emitter.MinParticleVelocity, scrollingStack);
			minVelocity.OnVectorEdited += (obj, e) =>
			{
				particleAction.Emitter.MinParticleVelocity = e.Vector;
			};

			//max velocity (vector)
			var maxVelocity = AddVectorEdit("max velocity", particleAction.Emitter.MaxParticleVelocity, scrollingStack);
			maxVelocity.OnVectorEdited += (obj, e) =>
			{
				particleAction.Emitter.MaxParticleVelocity = e.Vector;
			};


			//num start particles (int)
			CreateLabel("num start particles", scrollingStack);
			var numStartParticles = CreateNumEditBox(particleAction.Emitter.NumStartParticles, scrollingStack);
			numStartParticles.OnNumberEdited += (obj, e) =>
			{
				particleAction.Emitter.NumStartParticles = (int)numStartParticles.Number;
			};

			//Color (color edit)
			var color = AddColorEdit("Color:", particleAction.Emitter.ParticleColor, scrollingStack);
			color.OnColorEdited += (obj, e) =>
			{
				particleAction.Emitter.ParticleColor = e.Color;
			};

			//gravity (float)
			CreateLabel("gravity", scrollingStack);
			var gravity = CreateNumEditBox(particleAction.Emitter.ParticleGravity, scrollingStack);
			gravity.OnNumberEdited += (obj, e) =>
			{
				particleAction.Emitter.ParticleGravity = gravity.Number;
			};

			//particle life (float)
			CreateLabel("particle life", scrollingStack);
			var particleLife = CreateNumEditBox(particleAction.Emitter.ParticleLife, scrollingStack);
			particleLife.OnNumberEdited += (obj, e) =>
			{
				particleAction.Emitter.ParticleLife = particleLife.Number;
			};

			//particle size (float)
			CreateLabel("particle size", scrollingStack);
			var particleSize = CreateNumEditBox(particleAction.Emitter.ParticleSize, scrollingStack);
			particleSize.OnNumberEdited += (obj, e) =>
			{
				particleAction.Emitter.ParticleSize = particleSize.Number;
			};

			//add the scroller
			scroller.AddItem(scrollingStack);
			AddItem(scroller);
		}

		#endregion //Methods
	}
}
