using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ElementaryMagicians.Player
{
    public class MagicianMovingState : MagicianState
    {
        [SerializeField]
        private float m_sqrDistanceToMove = 0.3f;

        public override void EnterState()
        {
            base.EnterState();
        }
        public override void FixedUpdateState()
        {
            base.FixedUpdateState();
            if((m_magicianController.Agent.transform.position - m_magicianController.PositionTarget.position).sqrMagnitude > m_sqrDistanceToMove)
            {
                m_magicianController.Agent.SetDestination(m_magicianController.PositionTarget.position);
            }
            
           
        }

        public override void ExitState()
        {
            base.ExitState();
        }
    }
}
