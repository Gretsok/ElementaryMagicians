using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ElementaryMagicians.Combat
{
    [System.Serializable]
    public class Frost : Effect
    {
        protected float m_startingSpeed = 0f;
        protected float m_speedMultiplier = 1f;
        public Frost(Ennemy.EnnemyAI ennemy, float duration, float speedMultiplier) : base(ennemy, duration)
        {
            m_speedMultiplier = speedMultiplier;
        }

        public override void OnEffectStarted()
        {
            base.OnEffectStarted();
            m_startingSpeed = m_ennemy.Agent.speed;
            m_ennemy.Agent.speed *= m_speedMultiplier;
        }

        public override void OnEffectEnded()
        {
            m_ennemy.Agent.speed = m_startingSpeed;
            base.OnEffectEnded();
        }

        public void UpdateDuration(float duration)
        {
            m_duration = duration;
            ResetDuration();
        }
        public void ResetDuration()
        {
            m_timeOfStart = Time.time;
        }
    }
}