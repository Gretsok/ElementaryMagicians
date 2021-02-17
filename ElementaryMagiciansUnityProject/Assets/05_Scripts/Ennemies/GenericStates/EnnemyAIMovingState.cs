using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ElementaryMagicians.Ennemy
{
    public class EnnemyAIMovingState : EnnemyAIState
    {
        private Dunjeon.DunjeonRoomGameMode m_gamemode = null;
        [SerializeField]
        private float m_sqrDistanceToPositionToReachToChangePositionToReach = 1.3f;
        private Vector3 m_positionToReach = Vector3.zero;

        private void Start()
        {
            m_gamemode = MOtter.MOtterApplication.GetInstance().GAMEMANAGER.GetCurrentMainStateMachine<Dunjeon.DunjeonRoomGameMode>();
        }

        public override void EnterState()
        {
            base.EnterState();
            m_positionToReach = m_gamemode.GetGroundTile().Position + Vector3.up;
            m_owner.Agent.SetDestination(m_positionToReach);
        }

        public override void LateUpdateState()
        {
            base.LateUpdateState();
            if((m_owner.transform.position - m_positionToReach).sqrMagnitude < m_sqrDistanceToPositionToReachToChangePositionToReach)
            {
                m_positionToReach = m_gamemode.GetGroundTile().Position + Vector3.up;
                m_owner.Agent.SetDestination(m_positionToReach);
            }
        }

        public override void ExitState()
        {
            m_owner.Agent.SetDestination(m_owner.transform.position);
            base.ExitState();
        }
    }
}