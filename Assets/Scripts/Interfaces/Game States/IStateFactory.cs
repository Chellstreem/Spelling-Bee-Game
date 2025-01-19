using GameStates;
using System.Collections.Generic;

public interface IStateFactory
{
    public Dictionary<GameState, IGameState> CreateStates();
}