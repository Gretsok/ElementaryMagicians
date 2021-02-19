using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ElementaryMagicians.Player
{
    public class PlantMagicianController : MagicianController
    {
        [SerializeField]
        private PlantHealZone m_plantHealZonePrefab = null;

        internal override void PrimaryAttack()
        {
            try
            {
                base.PrimaryAttack();
                Instantiate(m_plantHealZonePrefab, transform.position, Quaternion.identity);
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