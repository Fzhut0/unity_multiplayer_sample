using Unity.BossRoom.Gameplay.GameplayObjects.Character;
using UnityEngine;

namespace Unity.BossRoom.Gameplay.Actions
{
    [CreateAssetMenu(menuName = "BossRoom/Actions/Aura Action")]
    public class AuraAction : Action

    {
        private bool m_IsRegenAuraStarted = false;
        private bool m_IsRegenAuraEnded = false;

        public override bool OnStart(ServerCharacter serverCharacter)
        {
            var amountToRegenerate = Config.Amount;
            var tickInterval = Config.AuraTickSeconds;
            var auraRadius = Config.Radius;

            if (serverCharacter.IsAuraRegenerating.Value)
            {
                serverCharacter.StopRegeneratingMana(auraRadius, amountToRegenerate, tickInterval);
                serverCharacter.IsAuraRegenerating.Value = false;
                Cancel(serverCharacter);
                return false;
            }
            serverCharacter.clientCharacter.RecvDoActionClientRPC(Data);
            serverCharacter.IsAuraRegenerating.Value = true;
            serverCharacter.StartRegeneratingMana(auraRadius, amountToRegenerate, tickInterval);
            return true;
        }


        public override void Reset()
        {
            base.Reset();
            m_IsRegenAuraEnded = false;
            m_IsRegenAuraStarted = false;
        }

        public override bool ShouldBecomeNonBlocking()
        {
            return TimeRunning >= Config.ExecTimeSeconds;
        }

        public override bool OnUpdate(ServerCharacter clientCharacter)
        {
            if (TimeRunning >= Config.ExecTimeSeconds && !m_IsRegenAuraStarted && !m_IsRegenAuraEnded)
            {
                m_IsRegenAuraStarted = true;
            }
            return !m_IsRegenAuraEnded;
        }

        public override bool OnUpdateClient(ClientCharacter clientCharacter)
        {
            return ActionConclusion.Continue;
        }


    }
}
