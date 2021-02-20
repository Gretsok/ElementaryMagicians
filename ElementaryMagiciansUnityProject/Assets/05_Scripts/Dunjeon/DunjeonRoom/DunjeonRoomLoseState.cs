using MOtter.StatesMachine;
using UnityEngine;

namespace ElementaryMagicians.Dunjeon
{
    public class DunjeonRoomLoseState : UIState
    {
        [SerializeField]
        private float m_timeToWait = 5f;
        [SerializeField]
        private ProjElf.SceneData.SceneData m_mainMenuScenedata = null;
        private float m_timeOfStart = float.MinValue;
        private bool m_timeWaited = false;
        public override void EnterState()
        {
            base.EnterState();
            GetPanel<GameOverPanel>().InflateRoomsPassed(DunjeonManager.GetInstance().NumberOfRoomsPassed);
            m_timeOfStart = Time.time;
        }

        public override void UpdateState()
        {
            base.UpdateState();
            if(Time.time - m_timeOfStart > m_timeToWait && !m_timeWaited)
            {
                m_mainMenuScenedata.LoadLevel();
                m_timeWaited = true;
            }
        }


    }
}