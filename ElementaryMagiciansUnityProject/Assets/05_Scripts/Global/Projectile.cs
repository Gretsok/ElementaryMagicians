using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ElementaryMagicians
{
    public class Projectile : MonoBehaviour
    {
        [SerializeField]
        private AnimationCurve m_inAirCurve = null;
        [SerializeField]
        private float m_speed = 12f;
        private Vector3 m_targetPositions = Vector3.zero;
        private Vector3 m_initPositions = Vector3.zero;
        private float m_yOffset = 0f;

        private float m_flatDistanceToTarget = 0f;
        private float m_initFlatDistanceToTarget = 0f;
        private bool m_hasLanded = false;


        public void Init(Vector3 initPosition)
        {
            transform.position = initPosition;
        }

        public void Throw(Vector3 targetPosition)
        {
            m_initPositions = transform.position;
            m_targetPositions = targetPosition;
            m_yOffset = transform.position.y - targetPosition.y;
            m_flatDistanceToTarget = (new Vector2(m_targetPositions.x, m_targetPositions.z) 
                - new Vector2(transform.position.x, transform.position.z)).magnitude;
            m_initFlatDistanceToTarget = m_flatDistanceToTarget;
        }

        private void FixedUpdate()
        {
            if(m_flatDistanceToTarget > 0.2f)
            {
                Vector2 flatDirection = new Vector2(m_targetPositions.x, m_targetPositions.z)
                - new Vector2(transform.position.x, transform.position.z);
                Vector3 flat3DDirection = (m_targetPositions - m_initPositions);
                flat3DDirection.y = 0;
                m_flatDistanceToTarget = flatDirection.magnitude;
                m_yOffset = Mathf.Lerp(m_yOffset, 0f, 1 - m_flatDistanceToTarget / m_initFlatDistanceToTarget);

                Vector3 m_nextPosition = transform.position
                    + flat3DDirection.normalized * m_speed * Time.fixedDeltaTime;
                m_nextPosition.y = m_targetPositions.y
                        + m_inAirCurve.Evaluate(1 - m_flatDistanceToTarget / m_initFlatDistanceToTarget)
                        - m_yOffset;
                transform.LookAt(m_nextPosition);
                transform.position = m_nextPosition;
            }
            else if(!m_hasLanded)
            {
                Land();
                m_hasLanded = true;
            }
        }

        protected virtual void Land()
        {
            Debug.Log("Land");
        }
    }
}