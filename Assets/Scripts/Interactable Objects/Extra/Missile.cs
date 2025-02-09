using Zenject;

namespace InteractableObjects
{
    public class Missile : InteractableObject
    {
        private IEventManager eventManager;

        [Inject]
        public void Construct(IEventManager eventManager)
        {
            this.eventManager = eventManager;            
        }

        protected override void OnPlayerCollision()
        {
            eventManager.Publish(new OnMissileCollision(transform.position));
            eventManager.Publish(new OnDeath());
            eventManager.Publish(new OnReturnedToPool(gameObject));
        }
    }
}
