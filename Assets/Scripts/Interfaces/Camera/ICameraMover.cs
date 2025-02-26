using Camera;
using UnityEngine;

public interface ICameraMover
{
    public void ChangeStateSmoothly(Transform cameraTransform, CameraStateType stateType, float duration);
    public void ChangeState(Transform cameraTransform, CameraStateType stateType);
}
