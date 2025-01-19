using Zenject;

using System.Collections.Generic;

namespace GameStates
{
    public class MovingStateManager : IEventSubscriber<OnMovingStarted>, IEventSubscriber<OnMovingStopped>
    {
        private IEventManager eventManager;
        private DiContainer container;

        private IGameState currentSubstate;
        private Dictionary<MovingStateSubstate, IGameState> subStates;

        public MovingStateManager(IEventManager eventManager, DiContainer container)
        {
            this.container = container;
            this.eventManager = eventManager;

            eventManager.Subscribe<OnMovingStarted>(this);
            eventManager.Subscribe<OnMovingStopped>(this);
        }

        public void SetSubstate(MovingStateSubstate substate)
        {
            currentSubstate?.Exit();
            currentSubstate = subStates[substate];
            currentSubstate.Enter();
        }

        public void OnEvent(OnMovingStarted eventData)
        {
            InitializeStates();
            SetSubstate(MovingStateSubstate.Interactive);
        }

        public void OnEvent(OnMovingStopped eventData)
        {
            currentSubstate?.Exit();
        }

        private void InitializeStates()
        {
            subStates = new Dictionary<MovingStateSubstate, IGameState>
        {
            { MovingStateSubstate.Safe, container.Resolve<SafeSubstate>() },
            { MovingStateSubstate.Interactive, container.Resolve<InteractiveSubstate>() }
        };
        }
    }
}

