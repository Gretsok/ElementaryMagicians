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
            base.PrimaryAttack();
            FireBall fireBall = Instantiate(m_fireBallPrefab);
            fireBall.Init(transform.position, transform.position + transform.forward, m_teamController.CombatController);
            fireBall.Cast();
        }

        internal override void SecondaryAttack()
        {
            base.SecondaryAttack();

        }
    }
}