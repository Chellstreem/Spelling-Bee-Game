using UnityEngine;

namespace Cameras
{
    public class CameraShakeHandler : IEventSubscriber<OnWordCompleted>, IEventSubscriber<OnMovingStateExit>
    {
        private readonly IEventManager eventManager;
        private readonly ICameraShaker cameraShaker;

        private float intensity;
        private float duration;

        public CameraShakeHandler(IEventManager eventManager, ICameraShaker cameraShaker, CameraConfig cameraConfig)
        {
            this.cameraShaker = cameraShaker;
            this.eventManager = eventManager;
            intensity = cameraConfig.CameraShakeIntensity;
            duration = cameraConfig.CameraShakeDuration;

            SubscribeToEvents();
        }

        public void OnEvent(OnWordCompleted eventData)
        {
            if (eventData.GameplayAction == GameplayActionType.CameraShake)
            {
                cameraShaker.ShakeCamera(intensity, duration);            
            }
        }

        public void OnEvent(OnMovingStateExit eventData)
        {
            cameraShaker.StopShaking();
        }

        private void SubscribeToEvents()
        {
            eventManager.Subscribe<OnWordCompleted>(this);
            eventManager.Subscribe<OnMovingStateExit>(this);
        }
    }
}
   
    
