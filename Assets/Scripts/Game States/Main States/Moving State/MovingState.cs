using System;

namespace GameStates
{
    public class MovingState : IGameState, IUpdatable, IEventSubscriber<OnVictory>, IEventSubscriber<OnDeath>
    {
        private readonly IStateSwitcher stateSwitcher;        
        private readonly IEventManager eventManager;
        private IInputHandler input;

        public MovingState(IStateSwitcher stateSwitcher, IEventManager eventManager, IInputHandler input)
        {
            this.stateSwitcher = stateSwitcher;            
            this.eventManager = eventManager;
            this.input = input;
        }

        public void Enter()
        {
            eventManager.Publish(new OnMovingStateEnter());
            SubscribeToEvents();
        }

        public void Exit()
        {
            eventManager.Publish(new OnMovingStateExit());
            UnsubscribeFromEvents();
        }

        public void Update() => input.HandleInput();        

        public void OnEvent(OnVictory eventData) => stateSwitcher.SetState(GameState.Victory);        

        public void OnEvent(OnDeath eventData) => stateSwitcher.SetState(GameState.Loss);

        private void SubscribeToEvents()
        {
            eventManager.Subscribe<OnDeath>(this);
            eventManager.Subscribe<OnVictory>(this);            
        }

        private void UnsubscribeFromEvents()
        {
            eventManager.Unsubscribe<OnDeath>(this);
            eventManager.Unsubscribe<OnVictory>(this);            
        }
    }
}