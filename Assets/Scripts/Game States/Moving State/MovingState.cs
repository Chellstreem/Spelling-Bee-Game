using System;

namespace GameStates
{
    public class MovingState : IGameState, IUpdatable, IEventSubscriber<OnVictory>, IEventSubscriber<OnDeath>
    {
        private IStateSwitcher stateSwitcher;
        private IHorizontalMovement playerMover;
        private IEventManager eventManager;
        private IInputHandler inputHandler;

        public MovingState(IStateSwitcher stateSwitcher, IHorizontalMovement playerMover, IEventManager eventManager, IInputHandler inputHandler)
        {
            this.stateSwitcher = stateSwitcher;
            this.playerMover = playerMover;
            this.eventManager = eventManager; 
            this.inputHandler = inputHandler;
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

        public void Update()
        {
            playerMover.Move();
            inputHandler.HandleInput();
        }

        public void OnEvent(OnVictory eventData)
        {
            stateSwitcher.SetState(GameState.Victory);
        }

        public void OnEvent(OnDeath eventData)
        {
            stateSwitcher.SetState(GameState.Loss);
        }

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