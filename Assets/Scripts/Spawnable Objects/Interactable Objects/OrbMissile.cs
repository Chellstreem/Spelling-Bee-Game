using Zenject;

namespace InteractableObjects
{
    public class OrbMissile : InteractableObject
    {
        private IEventManager eventManager;

        [Inject]
        public void Construct(IEventManager eventManager)
        {
            this.eventManager = eventManager;            
        }

        protected override void OnPlayerCollision()
        {
            eventManager.Publish(new OnOrbMissileCollected());
            eventManager.Publish(new OnReturnedToPool(gameObject));
        }
    }
}
