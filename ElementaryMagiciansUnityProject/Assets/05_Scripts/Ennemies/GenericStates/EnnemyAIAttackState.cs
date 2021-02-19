using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ElementaryMagicians.Ennemy
{
    public class EnnemyAIAttackState : EnnemyAIState
    {
        [SerializeField]
        private float m_attackSpeed = 1f;
        private float m_timeOfLastAttack = float.MinValue;
        [SerializeField]
        private float m_distanceToStartComingCloser = 2.0f;
        public override void UpdateState()
        {
            base.UpdateState();
            m_owner.transform.LookAt(m_owner.ClosestTarget.transform);
            if (Time.time - m_timeOfLastAttack > 1 / m_attackSpeed)
            {
                m_owner.Attack();
                m_timeOfLastAttack = Time.time;
            }


            if (m_owner.SqrDistanceToClosestTarget > m_distanceToStartComingCloser)
            {
                m_owner.SwitchToState(m_owner.ComingCloseToTarget);
            }
        }
    }
}