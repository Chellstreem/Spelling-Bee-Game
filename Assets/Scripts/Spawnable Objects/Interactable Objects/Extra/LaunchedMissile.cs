using UnityEngine;
using Zenject;

namespace InteractableObjects
{
    public class LaunchedMissile : InteractableObject, IWhooshable
    {
        private IEventManager eventManager;
        private ISoundEffectPlayer effectPlayer;        

        [Inject]
        public void Construct(IEventManager eventManager, ISoundEffectPlayer effectPlayer)
        {
            this.eventManager = eventManager;
            this.effectPlayer = effectPlayer;            
        }

        protected override void OnPlayerCollision()
        {
            eventManager.Publish(new OnMissileCollision(transform.position));
            eventManager.Publish(new OnBeingDamaged());
            eventManager.Publish(new OnReturnedToPool(gameObject));            
        }
        
        public void OnWhoosh()
        {
            effectPlayer.PlayEffect(SoundType.Whoosh);            
        }
    }
}
