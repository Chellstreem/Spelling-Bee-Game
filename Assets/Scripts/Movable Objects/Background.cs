using UnityEngine;
using System.Collections;

namespace MovableObjects
{
    public class Background : MovableObject, IEventSubscriber<OnMovingStateEnter>, IEventSubscriber<OnMovingStateExit>
    {        
        private Vector3 startPosition;        

        private void Awake()
        {
            startPosition = transform.position;

            eventManager.Subscribe<OnMovingStateEnter>(this);
            eventManager.Subscribe<OnMovingStateExit>(this);            
        }

        protected override IEnumerator MoveCoroutine()
        {
            while (true)
            {
                transform.Translate(Vector3.right * speed * Time.deltaTime);

                if (transform.position.z < thresholdZ)
                {
                    transform.position = startPosition;
                }

                yield return null;
            }
        }

        public void OnEvent(OnMovingStateEnter eventData)
        {
            StartMoving();
        }

        public void OnEvent(OnMovingStateExit eventData)
        {
            StopMoving();
        }

        private void OnDestroy()
        {
            eventManager.Unsubscribe<OnMovingStateEnter>(this);
            eventManager.Unsubscribe<OnMovingStateExit>(this);
        }
    }
}
