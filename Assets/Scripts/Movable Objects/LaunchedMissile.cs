using Zenject;
using Particles;
using UnityEngine;
using System.Collections;

namespace MovableObjects
{
    public class LaunchedMissile : MovableObject
    {
        [Inject]
        public override void Construct(IEventManager eventManager, ISpawnableObjectReturner objectReturner, GameConfig gameConfig)
        {
            this.eventManager = eventManager;
            this.objectReturner = objectReturner;
            speed = gameConfig.MissileSpeed;
            thresholdZ = gameConfig.ThresholdZ;
        }

        protected override IEnumerator MoveCoroutine()
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

        private void OnEnable() => StartMoving();       

        private void OnDisable() => StopMoving();       
    }
}
