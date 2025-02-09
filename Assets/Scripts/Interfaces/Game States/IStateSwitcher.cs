using GameStates;
public interface IStateSwitcher
{
    public IGameState CurrentState { get; }
    public void SetState(GameState state);    
}
