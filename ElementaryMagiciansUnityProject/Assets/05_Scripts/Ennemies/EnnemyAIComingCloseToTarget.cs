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

        public override void UpdateState()
        {
            base.UpdateState();
            if(m_owner.ClosestTarget != null)
            {
                m_owner.Agent.SetDestination(m_owner.ClosestTarget.transform.position);
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