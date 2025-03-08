using GameStates;
using System.Collections.Generic;

public interface IStateInitializer
{
    public void InitializeStates();
    public IGameState GetGameState(GameState gameState);
}