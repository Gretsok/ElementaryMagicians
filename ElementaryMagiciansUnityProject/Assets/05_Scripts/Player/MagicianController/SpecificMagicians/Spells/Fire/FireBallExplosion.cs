using ElementaryMagicians.Combat;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ElementaryMagicians.Player
{
    public class FireBallExplosion : MonoBehaviour, Combat.IDamageDealer
    {
        private bool m_hasStartedExploding = false;
        private float m_distanceTravelled = 0f;
        private float m_distanceToTravel = 10f;

        private CombatController m_owner = null;
        public CombatController Owner => m_owner;

        public Action<IDamageDealer> OnDestroy { get; set; }

        [SerializeField]
        private DamageDealerType m_dealerType = null;
        public DamageDealerType DealerType => m_dealerType;

        internal void Explode(CombatController owner)
        {
            transform.position += Vector3.down * 2f;
            m_hasStartedExploding = true;
            gameObject.SetActive(true);
            m_owner = owner;
        }

        internal void DoFixedUpdate()
        {
            if(m_hasStartedExploding)
            {
                if (m_distanceToTravel > m_distanceTravelled)
                {
                    Vector3 velocity = Vector3.up * 15f * Time.fixedDeltaTime;
                    transform.position += velocity;
                    m_distanceTravelled += velocity.magnitude;
                }
                else
                {
                    GetComponentInParent<Transform>().gameObject.SetActive(false);
                    OnDestroy?.Invoke(this);
                }
            }
        }



    }
}