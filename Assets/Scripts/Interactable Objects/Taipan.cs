using UnityEngine;
using Zenject;

namespace InteractableObjects
{
    public class Taipan : InteractableObject
    {
        private IEventManager eventManager;
        private ISoundEffectPlayer soundEffectPlayer;

        private Animator animator;
        private readonly int isBitten = Animator.StringToHash("isBitten");

        [Inject]
        public void Construct(IEventManager eventManager, ISoundEffectPlayer soundEffectPlayer)
        {
            this.eventManager = eventManager;
            this.soundEffectPlayer = soundEffectPlayer;
        }

        private void Awake()
        {
            animator = GetComponent<Animator>();
        }

        protected override void OnPlayerCollision()
        {
            eventManager.Publish(new OnDeath());
            animator.SetTrigger(isBitten);
            soundEffectPlayer.PlayEffect(SoundType.SnakeRattle);
        }
    }
}
