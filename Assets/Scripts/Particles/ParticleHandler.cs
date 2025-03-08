using UnityEngine;
using Zenject;

namespace Particles
{
    public class ParticleHandler : IEventSubscriber<OnLetterChecked>, IEventSubscriber<OnWordCompleted>,
        IEventSubscriber<OnVictory>, IEventSubscriber<OnDeath>, IEventSubscriber<OnMissileCollision>
    {
        private readonly IEventManager eventManager;
        private readonly IParticlePlayer player;        
        private Vector3 playerPosition;

        private readonly float confettiRainOffsetY = 14f;
        private readonly float delayForSoulEscape = 1.5f;

        public ParticleHandler(IEventManager eventManager, IParticlePlayer player,
            [Inject(Id = InstantiatedObjectType.Player)] Transform playerTransform)
        {
            this.eventManager = eventManager;
            this.player = player;            
            playerPosition = playerTransform.position;

            SubscribeToEvents();
        }

        public void OnEvent(OnLetterChecked eventData)
        {
            if (eventData.IsCorrect)
                player.PlayParticle(ParticleType.ArcadeSpark, eventData.Position);
            else
                player.PlayParticle(ParticleType.WrongText, eventData.Position);
                player.PlayParticle(ParticleType.Poof, eventData.Position + new Vector3(-1f, 0, 0));
        }

        public void OnEvent(OnWordCompleted eventData)
        {
            player.PlayParticle(ParticleType.BirthdayConfetti, playerPosition);
        }

        public void OnEvent(OnVictory eventData)
        {
            float x = playerPosition.x;
            float y = playerPosition.y + confettiRainOffsetY;
            float z = playerPosition.z;
            player.PlayParticle(ParticleType.ConfettiRain, new Vector3(x, y, z));
        }

        public void OnEvent(OnDeath eventData)
        {
            Vector3 offset = new Vector3(0, 2f, 0);
            player.PlayParticle(ParticleType.SoulEscape, playerPosition + offset, delayForSoulEscape);
        }

        public void OnEvent(OnMissileCollision eventData)
        {
            Vector3 offsetZ = new Vector3(0, 0, -3f);
            player.PlayParticle(ParticleType.MissileExplosion, eventData.Position + offsetZ);
        }        

        private void SubscribeToEvents()
        {
            eventManager.Subscribe<OnLetterChecked>(this);
            eventManager.Subscribe<OnWordCompleted>(this);
            eventManager.Subscribe<OnVictory>(this);
            eventManager.Subscribe<OnDeath>(this);
            eventManager.Subscribe<OnMissileCollision>(this);
        }

        private void UnsubscribeFromEvents()
        {
            eventManager.Unsubscribe<OnLetterChecked>(this);
            eventManager.Unsubscribe<OnWordCompleted>(this);
            eventManager.Unsubscribe<OnVictory>(this);
            eventManager.Unsubscribe<OnDeath>(this);
            eventManager.Unsubscribe<OnMissileCollision>(this);
        }
    }
}
