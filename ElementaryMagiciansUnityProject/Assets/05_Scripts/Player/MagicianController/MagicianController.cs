using ElementaryMagicians.Combat;
using MOtter.StatesMachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace ElementaryMagicians.Player
{
    internal class OnCooldownException : System.Exception
    {

    }
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
        protected MagicianTeamController m_teamController = null;

        [SerializeField]
        private MagicianFXManager m_fxManager = null;
        internal MagicianFXManager FXManager => m_fxManager;

        protected float m_cooldown = 0f;
        public float Cooldown => m_cooldown;

        [SerializeField]
        protected float m_primaryAttackCooldown = 3f;
        [SerializeField]
        protected float m_secondaryAttackCooldown = 3f;


        internal void Init(MagicianTeamController  magicianTeamController, Transform positionTarget, float speed)
        {
            transform.position = positionTarget.position;
            m_positionTarget = positionTarget;
            m_agent.speed = speed;
            m_teamController = magicianTeamController;
            EnterStateMachine();
        }

        internal void Init(MagicianTeamController magicianTeamController, Transform positionTarget, float speed, Vector3 spawnPosition)
        {
            transform.position = spawnPosition;
            m_positionTarget = positionTarget;
            m_agent.speed = speed;
            m_teamController = magicianTeamController;
            EnterStateMachine();
        }

        internal override void EnterStateMachine()
        {
            base.EnterStateMachine();
            GetComponent<CombatCollider>().SetOwner(m_teamController.CombatController);
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
            if(m_cooldown > 0)
            {
                m_cooldown -= Time.deltaTime;
            }
            
        }

        internal virtual void PrimaryAttack()
        {
            if(m_cooldown > 0)
            {
                throw new OnCooldownException();
            }
            m_cooldown = m_primaryAttackCooldown;
        }

        internal virtual void SecondaryAttack()
        {
            if (m_cooldown > 0)
            {
                throw new OnCooldownException();
            }
            m_cooldown = m_secondaryAttackCooldown;
        }
    }
}