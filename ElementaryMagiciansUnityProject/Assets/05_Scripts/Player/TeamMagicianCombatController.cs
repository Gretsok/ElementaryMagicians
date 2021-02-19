using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ElementaryMagicians.Player
{
    public class TeamMagicianCombatController : Combat.CombatController
    {
        protected override void Die()
        {
            base.Die();
            MOtter.MOtterApplication.GetInstance().GAMEMANAGER.GetCurrentMainStateMachine<Dunjeon.DunjeonRoomGameMode>().Lose();
        }
    }
}