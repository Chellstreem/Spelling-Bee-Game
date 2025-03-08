using UnityEngine;
using Zenject;

namespace InteractableObjects
{
    public class Taipan : InteractableObject, IWhooshable
    {
        private ISoundEffectPlayer soundEffectPlayer;
        private IDamageDealer damageDealer;

        private Animator animator;

        private readonly int damageAmount = 2;
        private readonly int isBitten = Animator.StringToHash("isBitten");

        [Inject]
        public void Construct(ISoundEffectPlayer soundEffectPlayer, IDamageDealer damageDealer)
        {            
            this.soundEffectPlayer = soundEffectPlayer;
            this.damageDealer = damageDealer;
        }

        private void Awake() => animator = GetComponent<Animator>();        

        protected override void OnPlayerCollision()
        {            
            animator.SetTrigger(isBitten);
            damageDealer.DamagePlayer(damageAmount);            
            soundEffectPlayer.PlayEffect(SoundType.SnakeRattle);
        }

        public void OnWhoosh()
        {
            soundEffectPlayer.PlayEffect(SoundType.SnakeRattle);
        }
    }
}
