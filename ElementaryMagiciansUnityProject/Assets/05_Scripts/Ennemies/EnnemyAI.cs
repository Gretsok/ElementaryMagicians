using MOtter.StatesMachine;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace ElementaryMagicians.Ennemy
{
    public class EnnemyAI : StatesMachine
    {
        [SerializeField]
        private NavMeshAgent m_agent = null;
        internal NavMeshAgent Agent => m_agent;
        [SerializeField]
        private EnnemyAIState m_walkingState = null;
        [SerializeField]
        private EnnemyAIState m_comingCloseToTarget = null;
        internal EnnemyAIState WalkingState => m_walkingState;

        [SerializeField]
        private MonsterAnimationsHandler m_animationsHandler = null;
        internal MonsterAnimationsHandler AnimationsHandler => m_animationsHandler;

        [SerializeField]
        private Combat.CombatController m_combatController = null;
        public Combat.CombatController CombatController => m_combatController;

        private List<Player.MagicianController> m_targets = new List<Player.MagicianController>();
        private Player.MagicianController m_closestTarget = null;
        private float m_sqrDistanceToClosestTarget = float.MaxValue;
        internal Player.MagicianController ClosestTarget => m_closestTarget;
        internal float SqrDistanceToClosestTarget => m_sqrDistanceToClosestTarget;
        internal override void EnterStateMachine()
        {
            base.EnterStateMachine();
            Agent.SetAreaCost(3, 10);
            Agent.SetAreaCost(4, 2);
            m_combatController.Init();
        }

        public override void DoUpdate()
        {
            base.DoUpdate();
            m_combatController.DoUpdate();
        }

        public override void DoLateUpdate()
        {
            base.DoLateUpdate();
            UpdateTargets();
        }

        private void UpdateTargets()
        {
            m_closestTarget = null;
            float sqrDistanceOfClosestTarget = float.MaxValue;
            for (int i = 0; i < m_targets.Count; ++i)
            {
                float sqrDistanceToTarget = (transform.position - m_targets[i].transform.position).sqrMagnitude;
                if (sqrDistanceToTarget < sqrDistanceOfClosestTarget)
                {
                    m_closestTarget = m_targets[i];
                    sqrDistanceOfClosestTarget = sqrDistanceToTarget;
                }
            }
            m_sqrDistanceToClosestTarget = sqrDistanceOfClosestTarget;
            if(m_closestTarget != null && m_currentState != m_comingCloseToTarget)
            {
                SwitchToState(m_comingCloseToTarget);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if(other.TryGetComponent<Player.MagicianController>(out Player.MagicianController magician))
            {
                m_targets.Add(magician);
            }
        }

        protected virtual void Attack()
        {
            
        }

        /*private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent<Player.MagicianController>(out Player.MagicianController magician))
            {
                if(m_targets.Contains(magician))
                {
                    m_targets.Remove(magician);
                }
            }
        }*/
    }
}