using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ElementaryMagicians.Combat
{
    public class CombatCollider : MonoBehaviour
    {
        class DamageDealerData
        {
            public IDamageDealer DamageDealer;
            public float LastTimeHit = float.MinValue;
        }
        [SerializeField]
        private CombatController m_owner = null;
        private List<DamageDealerData> m_damageDealerDatas = new List<DamageDealerData>();

        private void Start()
        {
            m_owner?.RegisterNewCombatColliders(this);
        }

        private void OnDestroy()
        {
            m_owner?.UnregisterNewCombatColliders(this);
        }

        internal void TakeDamage(int damage)
        {
            m_owner.TakeDamage(damage);
        }

        internal void DoUpdate()
        {
            ManageDamageDealer();
        }

        public void SetOwner(CombatController owner)
        {
            m_owner?.UnregisterNewCombatColliders(this);
            m_owner = owner;
            m_owner?.RegisterNewCombatColliders(this);
        }

        private void ManageDamageDealer()
        {
            for(int i = 0; i < m_damageDealerDatas.Count; ++i)
            {
                DamageDealerData currentDamageDealerData = m_damageDealerDatas[i];
                if(Time.time - currentDamageDealerData.LastTimeHit > currentDamageDealerData.DamageDealer.CooldownDamage)
                {
                    if(currentDamageDealerData.DamageDealer.Owner == null || currentDamageDealerData.DamageDealer.Owner.TeamIndex != m_owner.TeamIndex)
                    {
                        TakeDamage(currentDamageDealerData.DamageDealer.DamagePerHit);
                        currentDamageDealerData.LastTimeHit = Time.time;
                    }
                }
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if(other.TryGetComponent<IDamageDealer>(out IDamageDealer damageDealer))
            {
                DamageDealerData damageDealerData = m_damageDealerDatas.Find(x => x.DamageDealer == damageDealer);
                if(damageDealerData == null)
                {
                    damageDealerData = new DamageDealerData();
                    damageDealerData.DamageDealer = damageDealer;
                    damageDealer.OnDestroy += OnDamageDealerDestroyed;
                    m_damageDealerDatas.Add(damageDealerData);
                }
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent<IDamageDealer>(out IDamageDealer damageDealer))
            {
                DamageDealerData damageDealerData = m_damageDealerDatas.Find(x => x.DamageDealer == damageDealer);
                if(damageDealerData != null)
                {
                    m_damageDealerDatas.Remove(damageDealerData);
                }
            }
        }

        private void OnDamageDealerDestroyed(IDamageDealer damageDealer)
        {
            DamageDealerData damageDealerData = m_damageDealerDatas.Find(x => x.DamageDealer == damageDealer);
            if (damageDealerData != null)
            {
                m_damageDealerDatas.Remove(damageDealerData);
            }
        }
    }
}