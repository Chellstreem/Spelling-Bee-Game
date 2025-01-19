using UnityEngine;

namespace GameStates
{
    public class InteractiveSubstate : IGameState, IEventSubscriber<OnWordCompleted>
    {
        private MovingStateManager substateManager;
        private IEventManager eventManager;
        private IInteractableSpawner spawner;

        public InteractiveSubstate(MovingStateManager substateManager, IEventManager eventManager, IInteractableSpawner spawner)
        {
            this.substateManager = substateManager;
            this.eventManager = eventManager;
            this.spawner = spawner;

            eventManager.Subscribe<OnWordCompleted>(this);
        }

        public void Enter()
        {
            spawner.StartSpawning();
        }

        public void Exit()
        {
            spawner.StopSpawning();
        }

        public void OnEvent(OnWordCompleted eventData)
        {
            substateManager.SetSubstate(MovingStateSubstate.Safe);
        }
    }
}
