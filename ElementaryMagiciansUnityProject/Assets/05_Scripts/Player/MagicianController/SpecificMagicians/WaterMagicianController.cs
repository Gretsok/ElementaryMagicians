using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ElementaryMagicians.Player
{
    public class WaterMagicianController : MagicianController
    {
        [SerializeField]
        private int m_amountHealedWhenSpellUsed = 150;
        internal override void PrimaryAttack()
        {
            try
            {
                base.PrimaryAttack();
                m_teamController.CombatController.Heal(m_amountHealedWhenSpellUsed);
                m_teamController.GetWaterHealed();
            }
            catch(System.Exception e)
            {
                if(e is OnCooldownException)
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