using ElementaryMagicians.Combat;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ElementaryMagicians.Player
{
    public class IceSpikeExplosion : FireBallExplosion
    {
        [SerializeField]
        private float m_frostDuration = 3f;
        [SerializeField]
        private float m_frostSpeedMultiplier = 0.7f;
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<CombatCollider>(out CombatCollider combatCollider)
                && combatCollider.Owner.TryGetComponent<Ennemy.EnnemyAI>(out Ennemy.EnnemyAI ennemy))
            {
                Combat.Frost frostEffect = ennemy.EffectsApplied.Find(x => x is Combat.Frost) as Combat.Frost;
                if (frostEffect == null)
                {
                    ennemy.AddEffect(new Combat.Frost(ennemy, m_frostDuration, m_frostSpeedMultiplier));
                }
                else
                {
                    frostEffect.ResetDuration();
                }
            }
        }
    }
}