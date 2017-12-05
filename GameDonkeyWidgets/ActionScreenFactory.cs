using GameDonkeyLib;
using MenuBuddy;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameDonkeyWidgets
{
    public static class ActionScreenFactory
    {
		public static IScreen CreateStateActionScreen(BaseAction stateAction)
		{
			switch (stateAction.ActionType)
			{
				case EActionType.CameraShake:
					{
						return new CameraShakeActionScreen();
					}
				case EActionType.ParticleEffect:
					{
						return new ParticleEffectActionScreen();
					}
				case EActionType.PlayAnimation:
					{
						return new PlayAnimationActionScreen();
					}
				case EActionType.PlaySound:
					{
						return new PlaySoundActionScreen();
					}
				case EActionType.Projectile:
					{
						return new ProjectileActionScreen();
					}
				case EActionType.SendStateMessage:
					{
						return new SendStateMessageActionScreen();
					}
				case EActionType.Trail:
					{
						return new TrailActionScreen();
					}
				default:
					{
						return null;
					}
			}
		}
    }
}
