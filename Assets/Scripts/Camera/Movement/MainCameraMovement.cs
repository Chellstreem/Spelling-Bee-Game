using Cameras;
using UnityEngine;

public class MainCameraMovement : ISingleCameraMover
{
    private readonly Transform cameraTransform;
    private readonly IUniversalCameraMover cameraMover;    

    public MainCameraMovement(ICameraGetter cameraGetter, IUniversalCameraMover cameraMover)
    {
        cameraTransform = cameraGetter.GetCamera(CameraType.MainCamera).transform;
        this.cameraMover = cameraMover;
    }

    public void ChangeStateSmoothly(CameraStateType stateType, float duration)
    {
        cameraMover.ChangeStateSmoothly(cameraTransform, stateType, duration);
    }

    public void ChangeState(CameraStateType stateType)
    {
        cameraMover.ChangeState(cameraTransform, stateType);
    }
}
