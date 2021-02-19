using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ElementaryMagicians.Combat
{
    [System.Serializable]
    public class Effect
    {
        protected Ennemy.EnnemyAI m_ennemy = null;
        protected float m_duration = 0f;
        protected float m_timeOfStart = float.MinValue;
        public Effect(Ennemy.EnnemyAI ennemy, float duration)
        {
            m_ennemy = ennemy;
            m_duration = duration;
        }
        public virtual void OnEffectStarted()
        {
            m_timeOfStart = Time.time;
        }

        public virtual bool UpdateEffect()
        {
            if(Time.time - m_timeOfStart > m_duration)
            {
                return false;
            }
            return true;
        }

        public virtual void OnEffectEnded()
        {

        }
    }
}