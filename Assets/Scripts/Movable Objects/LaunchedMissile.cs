using Zenject;

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

        private void OnEnable() => StartMoving();       

        private void OnDisable() => StopMoving();       
    }
}
