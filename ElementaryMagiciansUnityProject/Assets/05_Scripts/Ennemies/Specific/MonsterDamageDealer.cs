using ElementaryMagicians.Combat;
using System;
using UnityEngine;

namespace ElementaryMagicians.Ennemy
{
    public class MonsterDamageDealer : MonoBehaviour, Combat.IDamageDealer
    {
        [SerializeField]
        private CombatController m_owner;
        public CombatController Owner => m_owner;

        public Action<IDamageDealer> OnDisappeared { get; set; }

        [SerializeField]
        private DamageDealerType m_damageDealerType = null;
        public DamageDealerType DealerType => m_damageDealerType;
    }
}