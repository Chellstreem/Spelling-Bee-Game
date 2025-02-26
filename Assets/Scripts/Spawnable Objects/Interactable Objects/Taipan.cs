using UnityEngine;
using Zenject;

namespace InteractableObjects
{
    public class Taipan : InteractableObject, IWhooshable
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
            eventManager.Publish(new OnBeingDamaged());
            animator.SetTrigger(isBitten);
            soundEffectPlayer.PlayEffect(SoundType.SnakeRattle);
        }

        public void OnWhoosh()
        {
            soundEffectPlayer.PlayEffect(SoundType.SnakeRattle);
        }
    }
}
