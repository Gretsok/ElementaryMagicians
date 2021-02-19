using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ElementaryMagicians.Combat
{
    public class CombatController : MonoBehaviour
    {
        [SerializeField]
        private int m_maxLifePoints = 1000;
        private int m_lifePoints = 0;
        public int MaxLifePoints => m_maxLifePoints;
        public int LifePoints => m_lifePoints;

        [SerializeField]
        private int m_teamIndex = 0;
        internal int TeamIndex => m_teamIndex;

        private List<CombatCollider> m_combatColliders = new List<CombatCollider>();

        internal void RegisterNewCombatColliders(CombatCollider combatCollider)
        {
            m_combatColliders.Add(combatCollider);
        }

        internal void UnregisterNewCombatColliders(CombatCollider combatCollider)
        {
            m_combatColliders.Remove(combatCollider);
        }

        public void Init()
        {
            m_lifePoints = m_maxLifePoints;
        }

        public void DoUpdate()
        {
            for(int i = 0; i < m_combatColliders.Count; ++i)
            {
                m_combatColliders[i].DoUpdate();
            }
        }

        protected virtual void Die()
        {

        }

        internal void TakeDamage(int damage)
        {
            m_lifePoints -= damage;
            if(m_lifePoints <= 0)
            {
                Die();
            }
        }

        internal void Heal(int healthToRecover)
        {
            m_lifePoints += healthToRecover;
            m_lifePoints = Mathf.Clamp(m_lifePoints, 0, m_maxLifePoints);
        }

    }
}