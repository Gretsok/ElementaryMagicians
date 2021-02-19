using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ElementaryMagicians.Player
{
    public class PlantHealZone : MonoBehaviour
    {
        [SerializeField]
        private GameObject m_plantsContainer = null;
        [SerializeField]
        private SphereCollider m_collider = null;

        [SerializeField]
        private float m_lifeSpan = 8f;
        [SerializeField]
        private int m_amountToHeal = 40;
        [SerializeField]
        private float m_healCooldown = 0.7f;
        private float m_timeOfLastHealWave = float.MinValue;

        [Space(5f)]

        [SerializeField]
        private float m_startingLocalHeight = -3f;
        [SerializeField]
        private float m_finishingLocalHeight = 0f;
        [SerializeField]
        private float m_comingOutOfGroundDuration = 1f;
        [SerializeField]
        private float m_goingIntoGroundDuration = 1f;

        private List<Combat.CombatCollider> m_magiciansCombatColliders = new List<Combat.CombatCollider>();

        private void Awake()
        {
            Vector3 tempPos = m_plantsContainer.transform.localPosition;
            tempPos.y = m_startingLocalHeight;
            m_plantsContainer.transform.localPosition = tempPos;
            tempPos = m_collider.center;
            tempPos.y = m_startingLocalHeight;
            m_collider.center = tempPos;
            StartCoroutine(ColliderRoutine());
        }

        private void Update()
        {
            if(Time.time - m_timeOfLastHealWave > m_healCooldown)
            {
                for(int i = 0; i < m_magiciansCombatColliders.Count; ++i)
                {
                    m_magiciansCombatColliders[i].Owner.Heal(m_amountToHeal);
                }
                m_timeOfLastHealWave = Time.time;
            }
        }



        private IEnumerator ColliderRoutine()
        {
            float timeOfLastIteration = Time.time;
            yield return null;
            while (m_plantsContainer.transform.localPosition.y < m_finishingLocalHeight)
            {
                Vector3 movementToAdd = Vector3.up * (1 / m_comingOutOfGroundDuration) * (Time.time - timeOfLastIteration);
                m_plantsContainer.transform.localPosition += movementToAdd;
                m_collider.center += movementToAdd;
                timeOfLastIteration = Time.time;
                yield return null;
            }

            yield return new WaitForSeconds(m_lifeSpan);
            timeOfLastIteration = Time.time;
            yield return null;
            while (m_plantsContainer.transform.localPosition.y > m_startingLocalHeight)
            {
                Vector3 movementToAdd = Vector3.down * (1 / m_goingIntoGroundDuration) * (Time.time - timeOfLastIteration);
                m_plantsContainer.transform.localPosition += movementToAdd;
                m_collider.center += movementToAdd;
                timeOfLastIteration = Time.time;
                yield return null;
            }
            Destroy(gameObject);
        }

        private void OnTriggerEnter(Collider other)
        {
            if(other.TryGetComponent<MagicianController>(out MagicianController magician)
                && magician.TryGetComponent<Combat.CombatCollider>(out Combat.CombatCollider collider)
                && !m_magiciansCombatColliders.Contains(collider))
            {
                m_magiciansCombatColliders.Add(collider);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent<MagicianController>(out MagicianController magician)
                && magician.TryGetComponent<Combat.CombatCollider>(out Combat.CombatCollider collider)
                && m_magiciansCombatColliders.Contains(collider))
            {
                m_magiciansCombatColliders.Remove(collider);
            }
        }


    }
}