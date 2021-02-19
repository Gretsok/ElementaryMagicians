using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ElementaryMagicians.Player
{
    public class FireMagicianController : MagicianController
    {
        [SerializeField]
        private FireBall m_fireBallPrefab = null;

        internal override void PrimaryAttack()
        {            
            try
            {
                base.PrimaryAttack();
                FireBall fireBall = Instantiate(m_fireBallPrefab);
                fireBall.Init(transform.position, m_teamController.WorldCursorPosition, m_teamController.CombatController);
                fireBall.Cast();
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