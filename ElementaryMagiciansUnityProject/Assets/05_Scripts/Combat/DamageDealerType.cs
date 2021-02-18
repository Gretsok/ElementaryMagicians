using UnityEngine;

namespace ElementaryMagicians.Combat
{
    [CreateAssetMenu(fileName = "DamageDealerType", menuName = "ElementaryMagicians/DamageDealerType")]
    public class DamageDealerType : ScriptableObject
    {
        [SerializeField]
        private int m_damageToDeal = 20;
        [SerializeField]
        private float m_cooldownBetweenTwoDamages = 1f;
        [SerializeField]
        private bool m_individualDealers = false;

        public int DamageToDeal => m_damageToDeal;
        public float CooldownBetweenTwoDamages => m_cooldownBetweenTwoDamages;
        public bool IndividualDealers => m_individualDealers;
    }
}