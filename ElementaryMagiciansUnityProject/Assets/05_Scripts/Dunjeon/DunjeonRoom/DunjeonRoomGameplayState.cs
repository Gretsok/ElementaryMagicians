using MOtter.StatesMachine;

namespace ElementaryMagicians.Dunjeon
{
    public class DunjeonRoomGameplayState : UIState
    {
        private DunjeonRoomGameMode m_gamemode = null;

        private MageTeamHealthBarPanel m_teamHealthBar = null;

        private void Start()
        {
            m_gamemode = MOtter.MOtterApplication.GetInstance().GAMEMANAGER.GetCurrentMainStateMachine<DunjeonRoomGameMode>();
        }

        public override void EnterState()
        {
            base.EnterState();
            for (int i = m_gamemode.Ennemies.Count - 1; i >= 0; --i)
            {
                m_gamemode.Ennemies[i].EnterStateMachine();
            }
            m_teamHealthBar = GetPanel<MageTeamHealthBarPanel>();
        }

        public override void UpdateState()
        {
            base.UpdateState();
            m_gamemode.MagicianTeamController.DoUpdate();
            m_teamHealthBar.SetHealth(
                (float)m_gamemode.MagicianTeamController.CombatController.LifePoints
                / (float)m_gamemode.MagicianTeamController.CombatController.MaxLifePoints);
            for(int i = m_gamemode.Ennemies.Count - 1; i >= 0; --i)
            {
                m_gamemode.Ennemies[i].DoUpdate();
            }
        }

        public override void FixedUpdateState()
        {
            base.FixedUpdateState();
            m_gamemode.MagicianTeamController.DoFixedUpdate();
            for (int i = m_gamemode.Ennemies.Count - 1; i >= 0; --i)
            {
                m_gamemode.Ennemies[i].DoFixedUpdate();
            }
        }

        public override void LateUpdateState()
        {
            base.LateUpdateState();
            m_gamemode.MagicianTeamController.DoLateUpdate();
            for (int i = m_gamemode.Ennemies.Count - 1; i >= 0; --i)
            {
                m_gamemode.Ennemies[i].DoLateUpdate();
            }
        }

        public override void ExitState()
        {
            for (int i = m_gamemode.Ennemies.Count - 1; i >= 0; --i)
            {
                m_gamemode.Ennemies[i].ExitStateMachine();
            }
            base.ExitState();
        }
    }
}