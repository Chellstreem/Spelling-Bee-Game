using Zenject;
using Particles;
using UnityEngine;
using System.Collections;

namespace MovableObjects
{
    public class LaunchedMissile : MovableObject
    {
        [Inject]
        public override void Construct(IEventManager eventManager, IParticlePlayer particlePlayer, GameConfig gameConfig)
        {
            this.eventManager = eventManager; 
            this.particlePlayer = particlePlayer;
            speed = gameConfig.MissileSpeed;
            thresholdZ = gameConfig.ThresholdZ;
        }
         
        protected override IEnumerator MoveCoroutine()
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

        private void OnEnable() => StartMoving();       

        private void OnDisable() => StopMoving();       
    }
}
