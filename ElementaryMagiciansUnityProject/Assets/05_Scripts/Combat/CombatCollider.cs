using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ElementaryMagicians.Combat
{
    public class CombatCollider : MonoBehaviour
    {
        [System.Serializable]
        class DamageDealerData
        {
            public List<IDamageDealer> DamageDealers = new List<IDamageDealer>();
            public float LastTimeHit = float.MinValue;
            public DamageDealerType DealerType = null;
        }

        public List<IDamageDealer> m_collidingDamageDealers = new List<IDamageDealer>();
        [SerializeField]
        private CombatController m_owner = null;
        public CombatController Owner => m_owner;

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

        protected virtual void ManageDamageDealer()
        {
            for(int i = m_damageDealerDatas.Count - 1; i >= 0; --i)
            {
                DamageDealerData currentDamageDealerData = m_damageDealerDatas[i];

                if (Time.time - currentDamageDealerData.LastTimeHit > currentDamageDealerData.DealerType.CooldownBetweenTwoDamages)
                {

                    for (int j = currentDamageDealerData.DamageDealers.Count - 1; j >= 0; --j)
                    {
                        IDamageDealer currentDamageDealer = currentDamageDealerData.DamageDealers[j];
                        try
                        {
                            if(!currentDamageDealer.gameObject.activeInHierarchy)
                            {
                                if (!m_collidingDamageDealers.Contains(currentDamageDealer))
                                {
                                    m_collidingDamageDealers.Remove(currentDamageDealer);
                                }
                            }
                        }
                        catch (System.Exception)
                        {
                            if (!m_collidingDamageDealers.Contains(currentDamageDealer))
                            {
                                m_collidingDamageDealers.Remove(currentDamageDealer);
                            }
                        }

                        if (!m_collidingDamageDealers.Contains(currentDamageDealer))
                        {
                            currentDamageDealerData.DamageDealers.Remove(currentDamageDealer);
                        }

                            
 
                    }

                    if (currentDamageDealerData.DamageDealers.Count == 0)
                    {
                        m_damageDealerDatas.Remove(currentDamageDealerData);
                        continue;
                    }
                    TakeDamage(currentDamageDealerData.DealerType.DamageToDeal);
                    currentDamageDealerData.LastTimeHit = Time.time;
                }
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if(other.TryGetComponent<IDamageDealer>(out IDamageDealer damageDealer))
            {
                if(damageDealer.Owner == null || damageDealer.Owner.TeamIndex != m_owner.TeamIndex)
                {
                    DamageDealerData damageDealerData = m_damageDealerDatas.Find(x => x.DealerType == damageDealer.DealerType);
                    if (damageDealerData == null || damageDealerData.DealerType.IndividualDealers)
                    {
                        damageDealerData = new DamageDealerData();
                        damageDealerData.DealerType = damageDealer.DealerType;
                        damageDealerData.DamageDealers.Add(damageDealer);
                        damageDealer.OnDisappeared += OnDamageDealerDestroyed;
                        m_damageDealerDatas.Add(damageDealerData);
                    }
                    else
                    {
                        if (!damageDealerData.DamageDealers.Contains(damageDealer))
                        {
                            damageDealerData.DamageDealers.Add(damageDealer);
                            damageDealer.OnDisappeared += OnDamageDealerDestroyed;
                        }
                    }
                    m_collidingDamageDealers.Add(damageDealer);
                }
                
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent<IDamageDealer>(out IDamageDealer damageDealer))
            {
                m_collidingDamageDealers.Remove(damageDealer);
            }
        }

        private void OnDamageDealerDestroyed(IDamageDealer damageDealer)
        {
            DamageDealerData damageDealerData = m_damageDealerDatas.Find(x => x.DealerType == damageDealer.DealerType);
            if (damageDealerData != null && damageDealerData.DamageDealers.Contains(damageDealer))
            {
                damageDealerData.DamageDealers.Remove(damageDealer);
            }
        }
    }
}