using System.Collections;
using UnityEngine;
using Zenject;

namespace MovableObjects
{
    public abstract class MovableObject : MonoBehaviour
    {
        protected IEventManager eventManager;
        protected IParticlePlayer particlePlayer;
        protected float speed;
        protected float thresholdZ;

        private Coroutine moveCoroutine;

        [Inject]
        public virtual void Construct(IEventManager eventManager, IParticlePlayer particlePlayer, GameConfig gameConfig)
        {
            this.eventManager = eventManager; 
            this.particlePlayer = particlePlayer;
            speed = gameConfig.Speed;
            thresholdZ = gameConfig.ThresholdZ;
        }

        protected virtual IEnumerator MoveCoroutine()
        {
            while (true)
            {
                transform.Translate(Vector3.back * speed * Time.deltaTime, Space.World);
                if (transform.position.z <= thresholdZ)
                {
                    StopMoving();
                    ReturnToOriginalState();
                }

                yield return null;
            }
        }

        protected void StartMoving()
        {
            if (moveCoroutine == null) moveCoroutine = StartCoroutine(MoveCoroutine());
        }

        protected void StopMoving()
        {
            if (moveCoroutine != null)
            {
                StopCoroutine(moveCoroutine);
            }

            moveCoroutine = null;
        }

        protected virtual void ReturnToOriginalState() => eventManager.Publish(new OnReturnedToPool(gameObject));
    }
}
