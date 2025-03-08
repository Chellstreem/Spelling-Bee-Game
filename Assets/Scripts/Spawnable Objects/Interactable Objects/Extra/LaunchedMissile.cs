using UnityEngine;
using Zenject;

namespace InteractableObjects
{
    public class LaunchedMissile : InteractableObject, IWhooshable
    {
        private IEventManager eventManager;
        private IDamageDealer damageDealer;
        private ISoundEffectPlayer effectPlayer;
        private ISpawnableObjectReturner returner;

        private readonly int damageAmount = 1;

        [Inject]
        public void Construct(IEventManager eventManager, IDamageDealer damageDealer,
            ISoundEffectPlayer effectPlayer, ISpawnableObjectReturner returner)
        {
            this.eventManager = eventManager;
            this.effectPlayer = effectPlayer;
            this.damageDealer = damageDealer;
            this.returner = returner;
        }

        protected override void OnPlayerCollision()
        {
            eventManager.Publish(new OnMissileCollision(transform.position));  
            damageDealer.DamagePlayer(damageAmount);
            returner.ReturnObject(gameObject);            
        }
        
        public void OnWhoosh()
        {
            effectPlayer.PlayEffect(SoundType.Whoosh);            
        }
    }
}
