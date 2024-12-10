using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LossState : IGameState
{
    private GameStateManager gameStateManager;

    public LossState(GameStateManager gameStateManager) => this.gameStateManager = gameStateManager;    

    public void Enter()
    {
        
    }

    public void Exit() { }
}
