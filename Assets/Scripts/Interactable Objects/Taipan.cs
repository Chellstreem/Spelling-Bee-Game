using UnityEngine;
using Zenject;

namespace InteractableObjects
{
    public class Taipan : InteractableObject
    {
        private IEventManager eventManager;

        private Animator animator;
        private int isBitten = Animator.StringToHash("isBitten");

        [Inject]
        public void Construct(IEventManager eventManager)
        {
            this.eventManager = eventManager;
        }

        private void Awake()
        {
            animator = GetComponent<Animator>();
        }

        protected override void OnPlayerCollision()
        {
            eventManager.Publish(new OnDeath());
            animator.SetTrigger(isBitten);
        }
    }
}
