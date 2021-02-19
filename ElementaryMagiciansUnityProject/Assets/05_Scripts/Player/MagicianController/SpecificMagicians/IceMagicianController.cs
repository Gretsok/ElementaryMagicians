using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ElementaryMagicians.Player
{
    public class IceMagicianController : MagicianController
    {
        [SerializeField]
        private IceSpike m_iceSpikePrefab = null;

        internal override void PrimaryAttack()
        {
            try
            {
                base.PrimaryAttack();
                IceSpike iceSpike = Instantiate(m_iceSpikePrefab);
                iceSpike.Init(transform.position + Vector3.up, m_teamController.WorldCursorPosition + Vector3.up, m_teamController.CombatController);
                iceSpike.Cast();
            }
            catch (System.Exception e)
            {
                if (e is OnCooldownException)
                {
                    Debug.LogWarning("Spell is on cooldown");
                }
            }
        }

        internal override void SecondaryAttack()
        {
            base.SecondaryAttack();

        }
    }
}