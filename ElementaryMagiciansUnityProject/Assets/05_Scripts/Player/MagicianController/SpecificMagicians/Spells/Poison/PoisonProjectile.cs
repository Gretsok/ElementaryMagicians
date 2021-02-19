using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ElementaryMagicians.Player
{
    public class PoisonProjectile : Projectile
    {
        [SerializeField]
        private LayerMask m_groundMask = 1;
        [SerializeField]
        private PoisonArea m_poisonAreaPrefab = null;
        private Combat.CombatController m_owner = null;

        public void SetOwner(Combat.CombatController owner)
        {
            m_owner = owner;
        }

        protected override void Land()
        {
            base.Land();
            if(Physics.Raycast(transform.position + Vector3.up, Vector3.down, out RaycastHit hitInfo, 10f, m_groundMask))
            {
                PoisonArea poisonArea = Instantiate(m_poisonAreaPrefab, hitInfo.point, Quaternion.identity);
                transform.position = hitInfo.point;
                poisonArea.Owner = m_owner;
            }
            else
            {
                Debug.DrawLine(transform.position + Vector3.up,
                    transform.position + Vector3.up + Vector3.down * 2f,
                    Color.red, 10f);
                Debug.LogError("COULD NOT LAND");
            }
            Invoke("AutoDestroy", 2f);
        }
        
        private void AutoDestroy()
        {
            Destroy(gameObject);
        }
    }
}