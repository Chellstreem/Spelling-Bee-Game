using Zenject;

namespace InteractableObjects
{
    public class OrbMissile : InteractableObject
    {
        private IEventManager eventManager;
        private ISpawnableObjectReturner returner;

        [Inject]
        public void Construct(IEventManager eventManager, ISpawnableObjectReturner returner)
        {
            this.eventManager = eventManager;   
            this.returner = returner;
        }

        protected override void OnPlayerCollision()
        {
            eventManager.Publish(new OnOrbMissileCollected());
            returner.ReturnObject(gameObject);
        }
    }
}
