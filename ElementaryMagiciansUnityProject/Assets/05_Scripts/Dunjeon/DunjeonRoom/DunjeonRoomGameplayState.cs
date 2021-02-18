using MOtter.StatesMachine;

namespace ElementaryMagicians.Dunjeon
{
    public class DunjeonRoomGameplayState : UIState
    {
        private DunjeonRoomGameMode m_gamemode = null;

        private MageTeamHealthBarPanel m_teamHealthBar = null;
        private MonstersHealthBarPanel m_monstersHealthBar = null;

        int m_ennemyTotalMaxLifePoints = 0;

        private void Start()
        {
            m_gamemode = MOtter.MOtterApplication.GetInstance().GAMEMANAGER.GetCurrentMainStateMachine<DunjeonRoomGameMode>();
        }

        public override void EnterState()
        {
            base.EnterState();
            m_ennemyTotalMaxLifePoints = 0;
            for (int i = m_gamemode.Ennemies.Count - 1; i >= 0; --i)
            {
                Ennemy.EnnemyAI currentEnnemy = m_gamemode.Ennemies[i];
                currentEnnemy.EnterStateMachine();
                m_ennemyTotalMaxLifePoints += currentEnnemy.CombatController.MaxLifePoints;
            }
            m_teamHealthBar = GetPanel<MageTeamHealthBarPanel>();
            m_monstersHealthBar = GetPanel<MonstersHealthBarPanel>();
        }

        public override void UpdateState()
        {
            base.UpdateState();
            m_gamemode.MagicianTeamController.DoUpdate();

            for(int i = m_gamemode.Ennemies.Count - 1; i >= 0; --i)
            {
                Ennemy.EnnemyAI currentEnnemy = m_gamemode.Ennemies[i];
                currentEnnemy.DoUpdate();
            }
        }

        public override void FixedUpdateState()
        {
            base.FixedUpdateState();
            m_gamemode.MagicianTeamController.DoFixedUpdate();
            for (int i = m_gamemode.Ennemies.Count - 1; i >= 0; --i)
            {
                Ennemy.EnnemyAI currentEnnemy = m_gamemode.Ennemies[i];
                currentEnnemy.DoFixedUpdate();
            }
        }

        public override void LateUpdateState()
        {
            base.LateUpdateState();
            m_gamemode.MagicianTeamController.DoLateUpdate();

            m_teamHealthBar.SetHealth(
    (float)m_gamemode.MagicianTeamController.CombatController.LifePoints
    / (float)m_gamemode.MagicianTeamController.CombatController.MaxLifePoints);

            int currentEnnemiesLife = 0;

            for (int i = m_gamemode.Ennemies.Count - 1; i >= 0; --i)
            {
                Ennemy.EnnemyAI currentEnnemy = m_gamemode.Ennemies[i];
                currentEnnemy.DoLateUpdate();
                currentEnnemiesLife += currentEnnemy.CombatController.LifePoints;
            }

            m_monstersHealthBar.SetHealth(
                (float) currentEnnemiesLife /
                (float) m_ennemyTotalMaxLifePoints);
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