using GameDonkeyLib;
using System;

namespace StatesTool
{
    public static class ActionScreenFactory
    {
        public static BaseActionScreen CreateStateActionScreen(BaseAction stateAction, IPlayerQueue character)
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
                case EActionType.SendToBack:
                    {
                        return new SendToBackActionScreen(stateAction, character);
                    }
                case EActionType.Trail:
                    {
                        return new TrailActionScreen(stateAction, character);
                    }
                case EActionType.ConstantDecceleration:
                    {
                        return new DeccelerationActionScreen(stateAction, character);
                    }
                case EActionType.AddVelocity:
                    {
                        return new AddVelocityActionScreen(stateAction, character);
                    }
                case EActionType.SetVelocity:
                    {
                        return new SetVelocityActionScreen(stateAction, character);
                    }
                case EActionType.ConstantAcceleration:
                    {
                        return new AccelerationActionScreen(stateAction, character);
                    }
                case EActionType.Random:
                    {
                        return new RandomActionScreen(stateAction, character);
                    }
                case EActionType.CreateAttack:
                    {
                        return new CreateAttackActionScreen(stateAction, character);
                    }
                case EActionType.CreateHitCircle:
                    {
                        return new CreateHitCircleActionScreen(stateAction, character);
                    }
                case EActionType.Block:
                    {
                        return new BlockActionScreen(stateAction, character);
                    }
                case EActionType.Shield:
                    {
                        return new ShieldActionScreen(stateAction, character);
                    }
                default:
                    {
                        throw new Exception($"{stateAction.ActionType.ToString()} screen has not been implemented yet.");
                    }
            }
        }
    }
}
