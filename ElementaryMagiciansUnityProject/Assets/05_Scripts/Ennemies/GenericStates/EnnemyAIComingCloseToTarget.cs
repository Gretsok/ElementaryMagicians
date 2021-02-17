using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ElementaryMagicians.Ennemy
{
    public class EnnemyAIComingCloseToTarget : EnnemyAIState
    {
        [SerializeField]
        private float m_sqrDistanceToStartAttacking = 1.5f;
        [SerializeField]
        private EnnemyAIState m_attackState = null;

        private float m_updateDestinationDelay = 0.5f;
        private float m_timeOfLastUpdate = float.MinValue;

        public override void UpdateState()
        {
            base.UpdateState();
            if(m_owner.ClosestTarget != null)
            {
                if(Time.time - m_timeOfLastUpdate > m_updateDestinationDelay)
                {
                    m_owner.Agent.SetDestination(m_owner.ClosestTarget.transform.position);
                    m_timeOfLastUpdate = Time.time;
                }
                
            }
            else if(m_owner.SqrDistanceToClosestTarget < m_sqrDistanceToStartAttacking)
            {
                m_owner.SwitchToState(m_attackState);
            }
            else
            {
                m_owner.SwitchToState(m_owner.WalkingState);
            }
            
        }

        public override void ExitState()
        {
            m_owner.Agent.SetDestination(m_owner.transform.position);
            base.ExitState();
        }
    }
}