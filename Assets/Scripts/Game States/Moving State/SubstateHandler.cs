namespace GameStates.Moving
{  
    public class SubstateHandler : IEventSubscriber<OnMovingStateEnter>, IEventSubscriber<OnMovingStateExit>
    {
        private readonly IEventManager eventManager;
        private readonly ISubstateSwitcher<MovingStateSubstate> substateSwitcher;
        private readonly ISubstateInitializer<MovingStateSubstate> substateInitializer;

        public SubstateHandler(IEventManager eventManager, ISubstateSwitcher<MovingStateSubstate> substateSwitcher, ISubstateInitializer<MovingStateSubstate> substateInitializer)
        {
            this.eventManager = eventManager;
            this.substateSwitcher = substateSwitcher;
            this.substateInitializer = substateInitializer;

            this.substateInitializer.InitializeSubstates();
            SubscribeToEvents();
        }

        public void OnEvent(OnMovingStateEnter eventData)
        {
            substateSwitcher.SetSubstate(MovingStateSubstate.Interactive);
        }

        public void OnEvent(OnMovingStateExit eventData)
        {
            substateSwitcher.ExitCurrentSubstate();
        }

        private void SubscribeToEvents()
        {
            eventManager.Subscribe<OnMovingStateEnter>(this);
            eventManager.Subscribe<OnMovingStateExit>(this);
        }
    }
}
