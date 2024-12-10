using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryState : IGameState
{
    private GameStateManager gameStateManager;       

    public VictoryState(GameStateManager gameStateManager) => this.gameStateManager = gameStateManager;     

    public void Enter() { }
    
    public void Exit() { }
}
