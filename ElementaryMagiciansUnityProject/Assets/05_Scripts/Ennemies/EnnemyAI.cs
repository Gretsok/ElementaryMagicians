﻿using MOtter.StatesMachine;
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
        internal EnnemyAIState ComingCloseToTarget => m_comingCloseToTarget;

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

        private List<Combat.Effect> m_effectsApplied = new List<Combat.Effect>();
        public List<Combat.Effect> EffectsApplied => m_effectsApplied;

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
            ManageEffects();
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
            if(m_closestTarget != null && m_currentState == m_walkingState)
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

        internal virtual void Attack()
        {
            m_animationsHandler.Attack();
        }

        internal void AddTarget(Player.MagicianController mage)
        {
            m_targets.Add(mage);
        }

        #region EffectsManagement
        public void AddEffect(Combat.Effect effect)
        {
            effect.OnEffectStarted();
            m_effectsApplied.Add(effect);
        }

        private void ManageEffects()
        {
            for(int i = m_effectsApplied.Count - 1; i >= 0; --i)
            {
                Combat.Effect currentEffect = m_effectsApplied[i];
                if(!currentEffect.UpdateEffect())
                {
                    currentEffect.OnEffectEnded();
                    m_effectsApplied.Remove(currentEffect);
                }
            }
        }
        #endregion


    }
}