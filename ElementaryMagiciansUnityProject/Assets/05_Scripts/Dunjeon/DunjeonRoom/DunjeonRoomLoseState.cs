using MOtter.StatesMachine;

namespace ElementaryMagicians.Dunjeon
{
    public class DunjeonRoomLoseState : UIState
    {
        public override void EnterState()
        {
            base.EnterState();
            GetPanel<GameOverPanel>().InflateRoomsPassed(DunjeonManager.GetInstance().NumberOfRoomsPassed);
        }
    }
}