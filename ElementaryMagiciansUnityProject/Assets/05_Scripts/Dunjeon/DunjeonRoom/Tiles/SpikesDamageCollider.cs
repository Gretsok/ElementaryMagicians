using ElementaryMagicians.Combat;
using System;
using UnityEngine;

namespace ElementaryMagicians.Dunjeon
{
    public class SpikesDamageCollider : MonoBehaviour, IDamageDealer
    {
        public CombatController Owner => null;


        private Action<IDamageDealer> m_onDestroy = null;
        public Action<IDamageDealer> OnDestroy { get => m_onDestroy; set => m_onDestroy = value; }

        [SerializeField]
        private DamageDealerType m_dealerType = null;
        public DamageDealerType DealerType => m_dealerType;
    }
}