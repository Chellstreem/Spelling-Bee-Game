using System;

namespace GameStates
{
    public class MovingState : IGameState, IUpdatable, IEventSubscriber<OnVictory>, IEventSubscriber<OnBeingDamaged>, IEventSubscriber<OnLetterChecked>
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

        public void OnEvent(OnVictory eventData)
        {
            stateSwitcher.SetState(GameState.Victory);
        }

        public void OnEvent(OnBeingDamaged eventData)
        {
            stateSwitcher.SetState(GameState.Loss);
        }

        public void OnEvent(OnLetterChecked eventData)
        {
            if (!eventData.IsCorrect)
                stateSwitcher.SetState(GameState.Loss);
        }

        private void SubscribeToEvents()
        {
            eventManager.Subscribe<OnBeingDamaged>(this);
            eventManager.Subscribe<OnVictory>(this);
            eventManager.Subscribe<OnLetterChecked>(this);
        }

        private void UnsubscribeFromEvents()
        {
            eventManager.Unsubscribe<OnBeingDamaged>(this);
            eventManager.Unsubscribe<OnVictory>(this);
            eventManager.Unsubscribe<OnLetterChecked>(this);
        }
    }
}