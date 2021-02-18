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

        public int DamageToDeal => m_damageToDeal;
        public float CooldownBetweenTwoDamages => m_cooldownBetweenTwoDamages;
    }
}