
namespace MovableObjects
{
    public class NonInteractableObject : MovableObject, IEventSubscriber<OnVictory>, IEventSubscriber<OnDeath>
    {
        private void OnEnable()
        {
            StartMoving();

            eventManager.Subscribe<OnDeath>(this);
            eventManager.Subscribe<OnVictory>(this);
        }

        private void OnDisable()
        {
            StopMoving();

            eventManager.Unsubscribe<OnDeath>(this);
            eventManager.Unsubscribe<OnVictory>(this);
        }

        private void OnDestroy()
        {
            eventManager.Unsubscribe<OnDeath>(this);
            eventManager.Unsubscribe<OnVictory>(this);
        }

        public void OnEvent(OnVictory eventData) => StopMoving();

        public void OnEvent(OnDeath eventData) => StopMoving();
    }
}
