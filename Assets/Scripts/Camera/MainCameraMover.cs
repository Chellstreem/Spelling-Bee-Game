using Camera;
using UnityEngine;

namespace Camera
{
    public class MainCameraMover : IMainCameraMover
    {
        private Transform mainCameraTransform;
        private ICameraMover cameraMover;
        private readonly float transitionDuration = 1.0f;

        public MainCameraMover(ICameraProvider cameraProvider, ICameraMover cameraMover)
        {
            mainCameraTransform = cameraProvider.GetMainCamera().transform;
            this.cameraMover = cameraMover;
        }

        public void ChangeStateSmoothly(CameraStateType stateType)
        {
            cameraMover.ChangeStateSmoothly(mainCameraTransform, stateType, transitionDuration);
        }

        public void ChangeState(CameraStateType stateType)
        {
            cameraMover.ChangeState(mainCameraTransform, stateType);
        }
    }
}
