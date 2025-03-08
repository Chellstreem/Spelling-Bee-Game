namespace MovableObjects
{
    public class NonInteractableObject : MovableObject, IEventSubscriber<OnMovingStateExit>
    {
        public void OnEvent(OnMovingStateExit eventData) => StopMoving();

        private void OnEnable()
        {
            StartMoving();
            eventManager.Subscribe<OnMovingStateExit>(this);
        }        

        private void OnDisable()
        {
            StopMoving();
            eventManager.Unsubscribe<OnMovingStateExit>(this);            
        }

        private void OnDestroy()
        {
            eventManager.Unsubscribe<OnMovingStateExit>(this);
        }
    }
}
