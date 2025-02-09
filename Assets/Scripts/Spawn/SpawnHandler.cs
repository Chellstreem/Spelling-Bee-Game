using Zenject;

namespace Spawn
{
    public class SpawnHandler : IEventSubscriber<OnMovingStateEnter>, IEventSubscriber<OnMovingStateExit>,
        IEventSubscriber<OnInteractiveSubstateEnter>, IEventSubscriber<OnInteractiveSubstateExit>, IEventSubscriber<OnMissileStateEnter>, IEventSubscriber<OnMissileStateExit>
    {
        private readonly IEventManager eventManager;
        private readonly ISpawner decorativeSpawner;
        private readonly ISpawner interactableSpawner;
        private readonly ISpawner missileSpawner;

        public SpawnHandler(
            IEventManager eventManager,
            [Inject(Id = "Decor")] ISpawner decorativeSpawner,
            [Inject(Id = "Interact")] ISpawner interactableSpawner,
            [Inject(Id = "Missile")] ISpawner missileSpawner)
        {
            this.eventManager = eventManager;
            this.decorativeSpawner = decorativeSpawner;
            this.interactableSpawner = interactableSpawner;
            this.missileSpawner = missileSpawner;
            
            SubscribeToEvents();            
        }

        public void OnEvent(OnMovingStateEnter eventData) => decorativeSpawner.StartSpawning();         

        public void OnEvent(OnMovingStateExit eventData) => decorativeSpawner.StopSpawning();       

        public void OnEvent(OnInteractiveSubstateEnter eventData) => interactableSpawner.StartSpawning();        

        public void OnEvent(OnInteractiveSubstateExit eventData) => interactableSpawner.StopSpawning();        

        public void OnEvent(OnMissileStateEnter eventData) => missileSpawner.StartSpawning();

        public void OnEvent(OnMissileStateExit eventData) => missileSpawner.StopSpawning();         

        private void SubscribeToEvents()
        {
            eventManager.Subscribe<OnMovingStateEnter>(this);
            eventManager.Subscribe<OnMovingStateExit>(this);
            eventManager.Subscribe<OnInteractiveSubstateEnter>(this);
            eventManager.Subscribe<OnInteractiveSubstateExit>(this);
            eventManager.Subscribe<OnMissileStateEnter>(this);
            eventManager.Subscribe<OnMissileStateExit>(this);
        }

        private void UnsubscribeFromEvents()
        {
            eventManager.Unsubscribe<OnMovingStateEnter>(this);
            eventManager.Unsubscribe<OnMovingStateExit>(this);
            eventManager.Unsubscribe<OnInteractiveSubstateEnter>(this);
            eventManager.Unsubscribe<OnInteractiveSubstateExit>(this);
            eventManager.Unsubscribe<OnMissileStateEnter>(this);
            eventManager.Unsubscribe<OnMissileStateExit>(this);
        }
    }
}
