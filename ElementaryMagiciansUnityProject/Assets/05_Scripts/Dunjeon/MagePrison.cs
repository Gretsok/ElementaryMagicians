using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ElementaryMagicians.Dunjeon
{
    public class MagePrison : MonoBehaviour
    {
        [SerializeField]
        private Transform m_mageSpawnPoint = null;
        private Player.MageData m_mageData = null;

        internal void Inflate(Player.MageData mageData)
        {
            m_mageData = mageData;
            Player.MagicianController magician = Instantiate(m_mageData.MagicianPrefab, m_mageSpawnPoint);
            magician.Agent.enabled = false;
            Destroy(magician);
        }

        private void OnTriggerEnter(Collider other)
        {
            if(other.TryGetComponent<Player.MagicianController>(out Player.MagicianController magician))
            {
                MOtter.MOtterApplication.GetInstance().GAMEMANAGER.GetCurrentMainStateMachine<DunjeonRoomGameMode>().MagicianTeamController.AddMagician(m_mageData, transform.position);
                Destroy(gameObject);
            }
        }
    }
}