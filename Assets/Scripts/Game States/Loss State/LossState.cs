

namespace GameStates
{
    public class LossState : IGameState
    {
        private readonly IEventManager eventManager;

        public LossState(IEventManager eventManager)
        {
            this.eventManager = eventManager;
        }       

        public void Enter()
        {
            eventManager.Publish(new OnLossStateEnter());
        }

        public void Exit() { }
    }
}
