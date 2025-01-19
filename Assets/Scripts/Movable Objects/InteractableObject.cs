using UnityEngine;

namespace MovableObjects
{
    public class InteractableObject : MovableObject, IEventSubscriber<OnWordCompleted>, IEventSubscriber<OnVictory>, IEventSubscriber<OnDeath>
    {
        private void OnEnable()
        {
            StartMoving();

            eventManager.Subscribe<OnDeath>(this);
            eventManager.Subscribe<OnVictory>(this);
            eventManager.Subscribe<OnWordCompleted>(this);
        }

        private void OnDisable()
        {
            StopMoving();

            eventManager.Unsubscribe<OnDeath>(this);
            eventManager.Unsubscribe<OnVictory>(this);
            eventManager.Unsubscribe<OnWordCompleted>(this);
        }

        private void OnDestroy()
        {
            eventManager.Unsubscribe<OnDeath>(this);
            eventManager.Unsubscribe<OnVictory>(this);
            eventManager.Unsubscribe<OnWordCompleted>(this);
        }

        public void OnEvent(OnWordCompleted eventData)
        {
            particlePlayer.PlayParticle(ParticleType.BasicSpark, transform.position);
            ReturnToOriginalState();
        }
        public void OnEvent(OnVictory eventData) => StopMoving();

        public void OnEvent(OnDeath eventData) => StopMoving();
    }
}
