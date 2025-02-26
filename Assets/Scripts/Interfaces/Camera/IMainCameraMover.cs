using Camera;

public interface IMainCameraMover
{
    public void ChangeStateSmoothly(CameraStateType stateType);
    public void ChangeState(CameraStateType stateType);
}
