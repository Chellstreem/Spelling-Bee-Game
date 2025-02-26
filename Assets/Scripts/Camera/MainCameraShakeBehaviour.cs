
namespace Camera
{
    public class MainCameraShakeBehaviour : IEventSubscriber<OnWordCompleted>, IEventSubscriber<OnMovingStateExit>
    {
        private readonly IEventManager eventManager;
        private readonly IMainCameraShaker cameraShaker;

        public MainCameraShakeBehaviour(IEventManager eventManager, IMainCameraShaker cameraShaker)
        {
            this.cameraShaker = cameraShaker;
            this.eventManager = eventManager;

            SubscribeToEvents();
        }

        public void OnEvent(OnWordCompleted eventData)
        {
            if (eventData.GameplayAction == GameplayActionType.CameraShake)
            {
                cameraShaker.ShakeMainCamera();
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
   
    
