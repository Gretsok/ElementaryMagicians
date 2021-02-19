using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ElementaryMagicians.Ennemy
{
    public class Crokodokus : EnnemyAI
    {
        [SerializeField]
        private RangeMonsterDamageDealer m_krokodokusProjectilePrefab = null;
        internal override void Attack()
        {
            base.Attack();
            RangeMonsterDamageDealer projectile = Instantiate(m_krokodokusProjectilePrefab);
            projectile.Init(transform.position + transform.forward, transform.position + transform.forward * 1.5f, CombatController);
            projectile.Cast();
        }
    }
}