using System;
using UnityEngine;

namespace ElementaryMagicians.Dunjeon
{
    public class Lava : Tile, Combat.IDamageDealer
    {
        public Combat.CombatController Owner => null;


        private Action<Combat.IDamageDealer> m_onDestroy = null;
        public Action<Combat.IDamageDealer> OnDisappeared { get => m_onDestroy; set => m_onDestroy = value; }

        [SerializeField]
        private Combat.DamageDealerType m_dealerType = null;
        public Combat.DamageDealerType DealerType => m_dealerType;

        [SerializeField]
        private Collider m_combatCollider = null;

        public override void Init()
        {
            base.Init();
            m_combatCollider.enabled = true;
        }
    }
}