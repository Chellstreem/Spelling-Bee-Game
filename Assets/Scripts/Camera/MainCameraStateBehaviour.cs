namespace Camera
{
    public class MainCameraStateBehaviour : IEventSubscriber<OnCountdownStateEnter>, IEventSubscriber<OnMovingStateEnter>, 
        IEventSubscriber<OnVictory>, IEventSubscriber<OnLossStateEnter>
    {
        private readonly IMainCameraMover cameraMover;        
        private readonly IEventManager eventManager;

        public MainCameraStateBehaviour(IMainCameraMover cameraMover, IMainCameraShaker cameraShaker, IEventManager eventManager)
        {
            this.cameraMover = cameraMover;            
            this.eventManager = eventManager;

            SubscribeToEvents();            
        }

        public void OnEvent(OnCountdownStateEnter eventData)
        {
            cameraMover.ChangeState(CameraStateType.Start);
        }

        public void OnEvent(OnMovingStateEnter eventData)
        {
            cameraMover.ChangeStateSmoothly(CameraStateType.Move);
        }

        public void OnEvent(OnVictory eventData)
        {
            cameraMover.ChangeStateSmoothly(CameraStateType.Victory);
        }

        public void OnEvent(OnLossStateEnter eventData)
        {
            cameraMover.ChangeStateSmoothly(CameraStateType.Loss);
        }        

        private void SubscribeToEvents()
        {
            eventManager.Subscribe<OnCountdownStateEnter>(this);
            eventManager.Subscribe<OnMovingStateEnter>(this);
            eventManager.Subscribe<OnVictory>(this);
            eventManager.Subscribe<OnLossStateEnter>(this);            
        }

        private void UnsubscribeFromEvents()
        {
            eventManager.Unsubscribe<OnCountdownStateEnter>(this);
            eventManager.Unsubscribe<OnMovingStateEnter>(this);
            eventManager.Unsubscribe<OnVictory>(this);
            eventManager.Unsubscribe<OnLossStateEnter>(this);            
        }
    }
}
