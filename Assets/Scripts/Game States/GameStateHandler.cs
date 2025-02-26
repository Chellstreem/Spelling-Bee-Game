using Zenject;

public class GameStateHandler : ITickable, IInitializable
{
    private readonly IStateInitializer stateInitializer;
    private readonly IStateSwitcher stateSwitcher;

    public GameStateHandler(IStateInitializer stateInitializer, IStateSwitcher stateSwitcher)
    {
        this.stateInitializer = stateInitializer;
        this.stateSwitcher = stateSwitcher;        
    }

    public void Initialize()
    {
        stateInitializer.InitializeStates();
        stateSwitcher.SetState(GameStates.GameState.Countdown);
    }

    public void Tick()
    {         
        if (stateSwitcher.CurrentState is IUpdatable updatableState)
            updatableState.Update();
    }
}
