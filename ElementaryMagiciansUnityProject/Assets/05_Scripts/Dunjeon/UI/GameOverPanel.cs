using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace ElementaryMagicians.Dunjeon
{
    public class GameOverPanel : Panel
    {
        [SerializeField]
        private TextMeshProUGUI m_roomsPassedText = null;

        public void InflateRoomsPassed(int nbOfRoomsPassed)
        {
            m_roomsPassedText.SetText("Rooms passed: " + nbOfRoomsPassed);
        }
    }
}