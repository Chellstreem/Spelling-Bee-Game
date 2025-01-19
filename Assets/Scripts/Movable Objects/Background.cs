using UnityEngine;
using System.Collections;

namespace MovableObjects
{
    public class Background : MovableObject, IEventSubscriber<OnMovingStarted>, IEventSubscriber<OnMovingStopped>
    {        
        private Vector3 startPosition;        

        private void Awake()
        {
            startPosition = transform.position;

            eventManager.Subscribe<OnMovingStarted>(this);
            eventManager.Subscribe<OnMovingStopped>(this);            
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

        public void OnEvent(OnMovingStarted eventData)
        {
            StartMoving();
        }

        public void OnEvent(OnMovingStopped eventData)
        {
            StopMoving();
        }

        private void OnDestroy()
        {
            eventManager.Unsubscribe<OnMovingStarted>(this);
            eventManager.Unsubscribe<OnMovingStopped>(this);
        }
    }
}
