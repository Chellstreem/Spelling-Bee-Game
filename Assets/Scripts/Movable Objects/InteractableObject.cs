using UnityEngine;
using Zenject;

namespace MovableObjects
{
    public class InteractableObject : MovableObject, IEventSubscriber<OnInteractiveSubstateExit>
    {
        private void OnEnable()
        {
            StartMoving();            
            eventManager.Subscribe<OnInteractiveSubstateExit>(this);
        }

        private void OnDisable()
        {
            StopMoving();            
            eventManager.Unsubscribe<OnInteractiveSubstateExit>(this);
        }

        private void OnDestroy()
        {            
            eventManager.Unsubscribe<OnInteractiveSubstateExit>(this);
        }

        public void OnEvent(OnInteractiveSubstateExit eventData)
        {
            particlePlayer.PlayParticle(ParticleType.BasicSpark, transform.position);
            ReturnToOriginalState();
        }       
    }
}
