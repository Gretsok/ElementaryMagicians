using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ElementaryMagicians.Ennemy
{
    public class EnnemyAICombatController : Combat.CombatController
    {
        protected override void Die()
        {
            base.Die();
            MOtter.MOtterApplication.GetInstance().GAMEMANAGER.GetCurrentMainStateMachine<Dunjeon.DunjeonRoomGameMode>().Ennemies.Remove(GetComponent<EnnemyAI>());
            Destroy(gameObject);
        }

    }
}