using Particles;
using Zenject;

namespace MovableObjects
{
    public class InteractableObject : MovableObject, IEventSubscriber<OnWordCompleted>, 
        IEventSubscriber<OnMovingStateExit>, IEventSubscriber<OnMissileStateEnter>
    {
        [Inject]
        private readonly IParticlePlayer particlePlayer;

        private void OnEnable()
        {
            SubscribeToEvents();
            StartMoving();
        }

        private void OnDisable()
        {
            StopMoving();
            UnsubscribeFromEvents();
        }

        private void OnDestroy()
        {
            UnsubscribeFromEvents();
        }

        public void OnEvent(OnWordCompleted eventData)
        {
            particlePlayer.PlayParticle(ParticleType.Poof, transform.position);
            ReturnToOriginalState();
        }

        public void OnEvent(OnMissileStateEnter eventData)
        {
            particlePlayer.PlayParticle(ParticleType.Poof, transform.position);
            ReturnToOriginalState();
        }

        public void OnEvent(OnMovingStateExit eventData) => StopMoving();        

        private void SubscribeToEvents()
        {
            eventManager.Subscribe<OnWordCompleted>(this);
            eventManager.Subscribe<OnMovingStateExit>(this);
            eventManager.Subscribe<OnMissileStateEnter>(this);
        }

        private void UnsubscribeFromEvents()
        {
            eventManager.Unsubscribe<OnWordCompleted>(this);
            eventManager.Unsubscribe<OnMovingStateExit>(this);
            eventManager.Unsubscribe<OnMissileStateEnter>(this);
        }
    }
}
