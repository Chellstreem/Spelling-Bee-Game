using System.Collections;
using UnityEngine;
using Zenject;

namespace MovableObjects
{
    public abstract class MovableObject : MonoBehaviour
    {
        protected IEventManager eventManager; 
        protected ISpawnableObjectReturner objectReturner;
        protected float speed;
        protected float thresholdZ;

        private Coroutine moveCoroutine;

        [Inject]
        public virtual void Construct(IEventManager eventManager, ISpawnableObjectReturner objectReturner, GameConfig gameConfig)
        {
            this.eventManager = eventManager;  
            this.objectReturner = objectReturner;
            speed = gameConfig.Speed;
            thresholdZ = gameConfig.ThresholdZ;
        }

        protected virtual IEnumerator MoveCoroutine()
        {
            while (true)
            {
                Vector3 newPosition = transform.position;
                newPosition += Vector3.back * (speed * Time.deltaTime);

                if (newPosition.z <= thresholdZ)
                {
                    StopMoving();
                    ReturnToOriginalState();
                }

                transform.position = newPosition;
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

        protected virtual void ReturnToOriginalState() => objectReturner.ReturnObject(gameObject);        
    }
}
