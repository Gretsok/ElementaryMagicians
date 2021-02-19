using MOtter.StatesMachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ElementaryMagicians.MainMenu
{
    public class MainMenuStateMachine : MainStatesMachine
    {
        [SerializeField]
        private ProjElf.SceneData.SceneData m_dunjeonSceneData = null;

        [SerializeField]
        private State m_mainMenuState = null;
        [SerializeField]
        private State m_creditstate = null;
        public void ClickPlay()
        {
            m_dunjeonSceneData.LoadLevel();
        }

        public void ClickQuit()
        {
            Application.Quit();
        }

        public void ClickCredits()
        {
            SwitchToState(m_creditstate);
        }

        public void ClickMainMenu()
        {
            SwitchToState(m_mainMenuState);
        }
    }
}