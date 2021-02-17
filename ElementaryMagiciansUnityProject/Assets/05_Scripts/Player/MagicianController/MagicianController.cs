using MOtter.StatesMachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace ElementaryMagicians.Player
{
    public class MagicianController : StatesMachine
    {
        private Transform m_positionTarget = null;
        internal Transform PositionTarget => m_positionTarget;
        [SerializeField]
        private NavMeshAgent m_agent = null;
        internal NavMeshAgent Agent => m_agent;
        [SerializeField]
        protected MagicianAnimationHandler m_animationsHandler = null;
        internal MagicianAnimationHandler AnimationHandler => m_animationsHandler;

        internal void Init(Transform positionTarget, float speed)
        {
            transform.position = positionTarget.position;
            m_positionTarget = positionTarget;
            m_agent.speed = speed;
            EnterStateMachine();
        }

        internal void Init(Transform positionTarget, float speed, Vector3 spawnPosition)
        {
            transform.position = spawnPosition;
            m_positionTarget = positionTarget;
            m_agent.speed = speed;
            EnterStateMachine();
        }

        internal void CleanUp()
        {
            ExitStateMachine();
        }

        public override void DoUpdate()
        {
            base.DoUpdate();
            m_animationsHandler.SetSpeedRatio(
                m_agent.velocity.magnitude
                / m_agent.speed);
            
        }

        internal virtual void PrimaryAttack()
        {

        }

        internal virtual void SecondaryAttack()
        {

        }
    }
}