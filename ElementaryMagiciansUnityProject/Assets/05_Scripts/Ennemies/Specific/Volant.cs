using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ElementaryMagicians.Ennemy
{
    public class Volant : EnnemyAI
    {
        [SerializeField]
        private RangeMonsterDamageDealer m_volantProjectilePrefab = null;
        internal override void Attack()
        {
            base.Attack();
            RangeMonsterDamageDealer projectile = Instantiate(m_volantProjectilePrefab);
            projectile.Init(transform.position + transform.forward, transform.position + transform.forward * 1.5f, CombatController);
            projectile.Cast();
        }
    }
}