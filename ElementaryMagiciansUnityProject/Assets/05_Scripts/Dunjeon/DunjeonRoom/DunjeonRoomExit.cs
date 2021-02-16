using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ElementaryMagicians.Dunjeon
{
    public class DunjeonRoomExit : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if(other.tag == "Player")
            {
                MOtter.MOtterApplication.GetInstance().GAMEMANAGER.GetCurrentMainStateMachine<DunjeonRoomGameMode>().LoadNextRoom();
            }
        }
    }
}