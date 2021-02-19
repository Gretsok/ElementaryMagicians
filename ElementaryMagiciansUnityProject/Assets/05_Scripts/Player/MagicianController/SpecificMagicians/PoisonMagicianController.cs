using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ElementaryMagicians.Player
{
    public class PoisonMagicianController : MagicianController
    {
        [SerializeField]
        private PoisonProjectile m_poisonProjectilePrefab = null;
        internal override void PrimaryAttack()
        {
            try
            {
                base.PrimaryAttack();
                PoisonProjectile poisonProjectile = Instantiate(m_poisonProjectilePrefab);
                poisonProjectile.Init(transform.position);
                poisonProjectile.Throw(m_teamController.WorldCursorPosition);
                poisonProjectile.SetOwner(m_teamController.CombatController);
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