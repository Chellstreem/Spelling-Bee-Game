using Cameras;
using UnityEngine;

public interface IUniversalCameraMover
{
    public void ChangeStateSmoothly(Transform cameraTransform, CameraStateType stateType, float duration);
    public void ChangeState(Transform cameraTransform, CameraStateType stateType);
}
