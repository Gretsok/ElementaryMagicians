using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ElementaryMagicians.Ennemy
{
    public class EnnemyAIAttackState : EnnemyAIState
    {
        public override void UpdateState()
        {
            base.UpdateState();
            m_owner.transform.LookAt(m_owner.ClosestTarget.transform);
        }
    }
}