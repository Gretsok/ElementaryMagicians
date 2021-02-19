using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ElementaryMagicians.Ennemy
{
    public class RangeMonsterDamageDealer : MonsterDamageDealer
    {
        [SerializeField]
        private float m_speed = 15f;
        private bool m_isTraveling = false;
        private bool m_toDestroy = false;

        internal void Init(Vector3 initPosition, Vector3 lookAtTarget, Combat.CombatController owner)
        {
            transform.position = initPosition;
            lookAtTarget.y = transform.position.y;
            transform.LookAt(lookAtTarget);
            m_owner = owner;
        }

        internal void Cast()
        {
            m_isTraveling = true;
        }

        private void FixedUpdate()
        {
            if(m_isTraveling)
            {
                transform.position += transform.forward * m_speed * Time.fixedDeltaTime;
            }
            else if(m_toDestroy)
            {
                OnDisappeared?.Invoke(this);
                Destroy(gameObject);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if(!(other.TryGetComponent<Combat.CombatCollider>(out Combat.CombatCollider collider)
                && collider.Owner == Owner))
            {
                m_toDestroy = true;
                m_isTraveling = false;
            }
        }
    }
}