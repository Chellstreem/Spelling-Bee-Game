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
                Vector3 newPosition = transform.position;
                newPosition += Vector3.back * (speed * Time.deltaTime);

                if (newPosition.z < thresholdZ)
                {
                    newPosition = startPosition;
                }

                transform.position = newPosition;
                yield return null;
            }
        }

        public void OnEvent(OnMovingStateEnter eventData) => StartMoving();        

        public void OnEvent(OnMovingStateExit eventData) => StopMoving();        

        private void OnDestroy()
        {
            eventManager.Unsubscribe<OnMovingStateEnter>(this);
            eventManager.Unsubscribe<OnMovingStateExit>(this);
        }
    }
}
