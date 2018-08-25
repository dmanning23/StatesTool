using GameDonkeyLib;
using MenuBuddy;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameDonkeyWidgets
{
    public static class ActionScreenFactory
    {
		public static BaseActionScreen CreateStateActionScreen(BaseAction stateAction, PlayerQueue character)
		{
			switch (stateAction.ActionType)
			{
				case EActionType.CameraShake:
					{
						return new CameraShakeActionScreen(stateAction, character);
					}
				case EActionType.ParticleEffect:
					{
						return new ParticleEffectActionScreen(stateAction, character);
					}
				case EActionType.PlayAnimation:
					{
						return new PlayAnimationActionScreen(stateAction, character);
					}
				case EActionType.PlaySound:
					{
						return new PlaySoundActionScreen(stateAction, character);
					}
				case EActionType.PointLight:
					{
						return new PointLightActionScreen(stateAction, character);
					}
				case EActionType.Projectile:
					{
						return new ProjectileActionScreen(stateAction, character);
					}
				case EActionType.SendStateMessage:
					{
						return new SendStateMessageActionScreen(stateAction, character);
					}
				case EActionType.Trail:
					{
						return new TrailActionScreen(stateAction, character);
					}
				case EActionType.ConstantDecceleration:
					{
						return new DeccelerationActionScreen(stateAction, character);
					}
				default:
					{
						return null;
					}
			}
		}
    }
}
