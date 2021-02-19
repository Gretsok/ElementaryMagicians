using ElementaryMagicians.Combat;
using System;
using UnityEngine;

namespace ElementaryMagicians.Player
{
    public class PoisonArea : MonoBehaviour, Combat.IDamageDealer
    {
        public CombatController Owner { get; set; } = null;

        public Action<IDamageDealer> OnDestroy { get; set; } = null;

        [SerializeField]
        private DamageDealerType m_dealerType = null;
        public DamageDealerType DealerType => m_dealerType;

        [SerializeField]
        private SphereCollider m_collider = null;
        private Vector3 m_centerCollider = Vector3.zero;
        private float m_interpolationValue = 0f;

        [SerializeField]
        private float m_lifeSpan = 5f;
        private float m_timeOfSpawn = float.MinValue;

        private void Start()
        {
            m_centerCollider = m_collider.center;
            m_centerCollider.y = -3.5f;
            m_interpolationValue = 0f;
            m_timeOfSpawn = Time.time;
        }

        private void FixedUpdate()
        {
            if(m_interpolationValue < 1f)
            {
                m_interpolationValue += Time.fixedDeltaTime * 3;
                m_centerCollider.y = Mathf.Lerp(m_centerCollider.y, 0, m_interpolationValue);
                m_collider.center = m_centerCollider;
            }
            else if(Time.time - m_timeOfSpawn > m_lifeSpan)
            {
                OnDestroy?.Invoke(this);
                Destroy(gameObject);
            }
            
        }

    }
}