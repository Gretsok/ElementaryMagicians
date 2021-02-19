using ElementaryMagicians.Combat;
using System;
using UnityEngine;


namespace ElementaryMagicians.Player
{
    public class FireBall : MonoBehaviour, Combat.IDamageDealer
    {
        [SerializeField]
        private float m_travelSpeed = 12f;

        private CombatController m_owner = null;
        public CombatController Owner => m_owner;

        private Action<IDamageDealer> m_onDestroy = null;
        public Action<IDamageDealer> OnDisappeared { get => m_onDestroy; set => m_onDestroy = value; }
        [SerializeField]
        private DamageDealerType m_dealerType = null;
        public DamageDealerType DealerType => m_dealerType;

        private bool m_isTraveling = false;
        private bool m_touchedSomething = false;

        [SerializeField]
        private FireBallExplosion m_explosion = null;
        [SerializeField]
        private GameObject m_fireBallObject = null;

        public void Init(Vector3 position, Vector3 lookAtTarget, CombatController owner)
        {
            
            transform.position = position;
            lookAtTarget.y = transform.position.y;
            transform.LookAt(lookAtTarget);
            m_owner = owner;
        }

        public void Cast()
        {
            m_isTraveling = true;
            m_fireBallObject.SetActive(true);
        }

        private void FixedUpdate()
        {
            if(m_isTraveling)
            {
                transform.position += transform.forward * m_travelSpeed * Time.fixedDeltaTime;
            }
            else if(m_touchedSomething)
            {
                m_onDestroy?.Invoke(this);
                m_explosion.DoFixedUpdate();
                m_touchedSomething = false;
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if(other.tag != "Player" && m_isTraveling)
            {
                m_isTraveling = false;
                m_touchedSomething = true;
                m_explosion.Explode(m_owner);
                m_fireBallObject.SetActive(false);
                
            }
        }

        private void OnDestroy()
        {
            m_onDestroy?.Invoke(this);
        }
    }
}