public interface ISubstateInitializer<TSubtateType>
{
    public void InitializeSubstates();
    public IGameState GetSubstate(TSubtateType state);    
}
