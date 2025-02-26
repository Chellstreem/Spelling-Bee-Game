using System;

namespace Sounds
{
    public class SoundEffectBehaviour : IEventSubscriber<OnBeingDamaged>, IEventSubscriber<OnLetterChecked>, IEventSubscriber<OnMissileCollision>,
        IEventSubscriber<OnLossStateEnter>, IEventSubscriber<OnOrbMissileCollected>, IEventSubscriber<OnMissileStateEnter>, 
        IEventSubscriber<OnCountdownTick>, IEventSubscriber<OnWordCompleted>      
    {
        private readonly IEventManager eventManager;
        private readonly ISoundEffectPlayer player;        

        public SoundEffectBehaviour(IEventManager eventManager, ISoundEffectPlayer soundEffectPlayer)
        {
            this.eventManager = eventManager;
            player = soundEffectPlayer;           

            SubscribeToEvents();
        }        

        public void OnEvent(OnBeingDamaged eventData)
        {
            SoundType type = UnityEngine.Random.value > 0.5 ? SoundType.Willhelm : SoundType.TomScream;
            player.PlayEffect(type);
        }

        public void OnEvent(OnLetterChecked eventData)
        {
            if (eventData.IsCorrect)
                player.PlayEffect(SoundType.Pick);
        }

        public void OnEvent(OnMissileCollision eventData) => player.PlayEffect(SoundType.MissileExplosion);

        public void OnEvent(OnLossStateEnter eventData) => player.PlayEffect(SoundType.SadTrombone);

        public void OnEvent(OnOrbMissileCollected eventData) => player.PlayEffect(SoundType.Pick);

        public void OnEvent(OnMissileStateEnter eventData) => player.PlayEffect(SoundType.MissileLockOn);

        public void OnEvent(OnWordCompleted eventData)
        {
            if (eventData.GameplayAction == GameplayActionType.CameraShake)
                player.PlayEffect(SoundType.Earthquake);
        }

        public void OnEvent(OnCountdownTick eventData)
        {
            if (eventData.Count != 0)
                player.PlayEffect(SoundType.Tick);
            else
                player.PlayEffect(SoundType.Go);
        }        

        private void SubscribeToEvents()
        {
            eventManager.Subscribe<OnCountdownTick>(this);
            eventManager.Subscribe<OnBeingDamaged>(this);
            eventManager.Subscribe<OnLetterChecked>(this);
            eventManager.Subscribe<OnMissileCollision>(this);
            eventManager.Subscribe<OnLossStateEnter>(this);
            eventManager.Subscribe<OnMissileStateEnter>(this);
            eventManager.Subscribe<OnWordCompleted>(this);
        }

        private void UnsubscribeFromEvents()
        {
            eventManager.Unsubscribe<OnCountdownTick>(this);
            eventManager.Unsubscribe<OnBeingDamaged>(this);
            eventManager.Unsubscribe<OnLetterChecked>(this);
            eventManager.Unsubscribe<OnMissileCollision>(this);
            eventManager.Unsubscribe<OnLossStateEnter>(this);
            eventManager.Unsubscribe<OnMissileStateEnter>(this);
            eventManager.Unsubscribe<OnWordCompleted>(this);
        }
    }
}
