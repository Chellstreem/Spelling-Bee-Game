using UnityEngine;

namespace Sounds
{
    public class SoundEffectHandler : IEventSubscriber<OnCountdownTick>, IEventSubscriber<OnDeath>, IEventSubscriber<OnLetterChecked>
    {
        private readonly IEventManager eventManager;
        private readonly ISoundEffectPlayer player;

        public SoundEffectHandler(IEventManager eventManager, ISoundEffectPlayer soundEffectPlayer)
        {
            this.eventManager = eventManager;
            player = soundEffectPlayer;

            SubscribeToEvents();
        }

        public void OnEvent(OnCountdownTick eventData)
        {
            if (eventData.Count != 0)
                player.PlayEffect(SoundType.Tick);
            else
                player.PlayEffect(SoundType.Go);
        }

        public void OnEvent(OnDeath eventData)
        {
            player.PlayEffect(SoundType.Willhelm);
        }

        public void OnEvent(OnLetterChecked eventData)
        {
            if (eventData.IsCorrect) player.PlayEffect(SoundType.Pick);
        }

        private void SubscribeToEvents()
        {
            eventManager.Subscribe<OnCountdownTick>(this);
            eventManager.Subscribe<OnDeath>(this);
            eventManager.Subscribe<OnLetterChecked>(this);
        }

        private void UnsubscribeFromEvents()
        {
            eventManager.Unsubscribe<OnCountdownTick>(this);
            eventManager.Unsubscribe<OnDeath>(this);
            eventManager.Unsubscribe<OnLetterChecked>(this);
        }

        private void OnDestroy()
        {
            UnsubscribeFromEvents();
        }
    }
}
