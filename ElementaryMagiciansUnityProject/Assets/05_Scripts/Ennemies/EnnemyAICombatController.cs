using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ElementaryMagicians.Ennemy
{
    public class EnnemyAICombatController : Combat.CombatController
    {
        [SerializeField]
        private float m_difficultyLifeFactor = 0.3f;
        public override void Init()
        {
            m_maxLifePoints *= (int)(1 + Dunjeon.DunjeonManager.GetInstance().NumberOfRoomsPassed * m_difficultyLifeFactor);
            base.Init();
        }
        protected override void Die()
        {
            base.Die();
            MOtter.MOtterApplication.GetInstance().GAMEMANAGER.GetCurrentMainStateMachine<Dunjeon.DunjeonRoomGameMode>().Ennemies.Remove(GetComponent<EnnemyAI>());
            Destroy(gameObject);
        }

    }
}