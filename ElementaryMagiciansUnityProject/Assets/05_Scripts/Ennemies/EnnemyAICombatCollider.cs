using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ElementaryMagicians.Ennemy
{
    public class EnnemyAICombatCollider : Combat.CombatCollider
    {

        protected override void ManageDamageDealer()
        {
            base.ManageDamageDealer();
            for(int i = 0; i < m_collidingDamageDealers.Count; ++i)
            {
                if(m_collidingDamageDealers[i].Owner.TryGetComponent<Player.MagicianTeamController>(out Player.MagicianTeamController mageTeam))
                {
                    Owner.GetComponent<EnnemyAI>().AddTarget(mageTeam.GetRandomMagician());
                }
            }

        }
    }
}