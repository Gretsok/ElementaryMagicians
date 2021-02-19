using ElementaryMagicians.Combat;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ElementaryMagicians.Player
{
    public class IceSpike : MonoBehaviour, IDamageDealer
    {
        [SerializeField]
        private float m_travelSpeed = 12f;

        private bool m_isTraveling = false;
        private bool m_touchedSomething = false;

        private CombatController m_owner = null;
        public CombatController Owner => m_owner;

        public Action<IDamageDealer> OnDestroy { get; set; }

        [SerializeField]
        private DamageDealerType m_damageDealerType = null;
        public DamageDealerType DealerType => m_damageDealerType;

        [SerializeField]
        private GameObject m_iceSpikeObject = null;
        [SerializeField]
        private IceSpikeExplosion m_explosion = null;

        [SerializeField]
        private float m_frostDuration = 5f;
        [SerializeField]
        private float m_frostSpeedMultiplier = 0.4f;


        public void Init(Vector3 position, Vector3 lookAtTarget, CombatController owner)
        {

            transform.position = position;
            transform.LookAt(lookAtTarget);
            m_owner = owner;
        }

        public void Cast()
        {
            m_isTraveling = true;
            m_iceSpikeObject.SetActive(true);
        }

        private void FixedUpdate()
        {
            if (m_isTraveling)
            {
                transform.position += transform.forward * m_travelSpeed * Time.fixedDeltaTime;
            }
            else if (m_touchedSomething)
            {
                m_explosion.DoFixedUpdate();
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag != "Player" && m_isTraveling)
            {
                m_isTraveling = false;
                m_touchedSomething = true;
                m_explosion.Explode(m_owner);
                OnDestroy?.Invoke(this);
                if (other.TryGetComponent<CombatCollider>(out CombatCollider combatCollider) 
                    && combatCollider.Owner.TryGetComponent<Ennemy.EnnemyAI>(out Ennemy.EnnemyAI ennemy))
                {
                    Frost frostEffect = ennemy.EffectsApplied.Find(x => x is Combat.Frost) as Frost;
                    if (frostEffect== null)
                    {
                        ennemy.AddEffect(new Combat.Frost(ennemy, m_frostDuration, m_frostSpeedMultiplier));
                    }
                    else
                    {
                        frostEffect.UpdateDuration(m_frostDuration);
                    }

                }
            }
        }
    }
}