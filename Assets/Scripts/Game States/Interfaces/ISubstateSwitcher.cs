public interface ISubstateSwitcher<TStateType>
{
    public void SetSubstate(TStateType substate);
    public void ExitCurrentSubstate();
}
