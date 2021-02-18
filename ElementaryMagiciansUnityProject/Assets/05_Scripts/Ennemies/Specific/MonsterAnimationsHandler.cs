using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ElementaryMagicians.Ennemy
{
    public class MonsterAnimationsHandler : MonoBehaviour
    {
        private int SPEEDRATIO = Animator.StringToHash("SpeedRatio");
        private int ATTACK = Animator.StringToHash("Attack");

        [SerializeField]
        private Animator m_animator = null;

        internal void SetSpeedRatio(float speedRatio)
        {
            m_animator.SetFloat(SPEEDRATIO, speedRatio);
        }

        internal void Attack()
        {
            m_animator.SetTrigger(ATTACK);
        }
    }
}