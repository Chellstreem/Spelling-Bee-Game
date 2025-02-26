using System;

namespace PlayerMobility
{
    public class PlayerMovementHandler : IDisposable, IEventSubscriber<OnVictory>
    {
        private readonly IEventManager eventManager;
        private readonly IPlayerMover playerMover;
        private readonly IInput input;

        public PlayerMovementHandler(IEventManager eventManager, IPlayerMover playerMover, IInput input)
        {
            this.eventManager = eventManager;
            this.playerMover = playerMover;
            this.input = input;

            SubscribeToEvents();            
        }

        public void OnEvent(OnVictory eventData)
        {
            playerMover.GoDown();
        }

        public void Dispose()
        {
            UnsubscribeFromEvents();
        }

        private void SubscribeToEvents()
        {
            input.ClickUp += playerMover.GoUp;
            input.ClickDown += playerMover.GoDown; 
            eventManager.Subscribe<OnVictory>(this);
        }

        private void UnsubscribeFromEvents()
        {
            input.ClickUp -= playerMover.GoUp;
            input.ClickDown -= playerMover.GoDown;
            eventManager.Unsubscribe<OnVictory>(this);
        }
    }
}
