using Cameras;

public interface ISingleCameraMover
{
    public void ChangeStateSmoothly(CameraStateType stateType, float duration);
    public void ChangeState(CameraStateType stateType);   
}
