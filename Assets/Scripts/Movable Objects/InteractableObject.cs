using Particles;
using Zenject;

namespace MovableObjects
{
    public class InteractableObject : MovableObject, IEventSubscriber<OnWordCompleted>, IEventSubscriber<OnBeingDamaged>
    {        
        private void OnEnable()
        {
            StartMoving();            
            eventManager.Subscribe<OnWordCompleted>(this);
            eventManager.Subscribe<OnBeingDamaged>(this);
        }

        private void OnDisable()
        {
            StopMoving();            
            eventManager.Unsubscribe<OnWordCompleted>(this);
            eventManager.Unsubscribe<OnBeingDamaged>(this);
        }

        private void OnDestroy()
        {            
            eventManager.Unsubscribe<OnWordCompleted>(this);
            eventManager.Unsubscribe<OnBeingDamaged>(this);
        }

        public void OnEvent(OnWordCompleted eventData)
        {
            particlePlayer.PlayParticle(ParticleType.ArcadeSpark, transform.position);
            ReturnToOriginalState();
        }

        public void OnEvent(OnBeingDamaged eventData)
        {
            StopMoving();
        }
    }
}
