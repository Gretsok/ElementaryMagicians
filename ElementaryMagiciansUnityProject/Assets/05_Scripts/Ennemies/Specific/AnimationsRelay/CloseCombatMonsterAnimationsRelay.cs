using UnityEngine;

namespace ElementaryMagicians.Ennemy
{
    public class CloseCombatMonsterAnimationsRelay : MonoBehaviour
    {
        [SerializeField]
        private MonsterDamageDealer m_damageDealer = null;
        public void StartAttacking()
        {
            m_damageDealer.gameObject.SetActive(true);
        }

        public void StopAttacking()
        {
            m_damageDealer.OnDisappeared?.Invoke(m_damageDealer);
            m_damageDealer.gameObject.SetActive(false);
        }
    }
}