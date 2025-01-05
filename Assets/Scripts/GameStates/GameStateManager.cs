using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    public enum GameState
    {
        Countdown,
        Moving,
        Victory,
        Loss
    }

    private PlayerMovement playerMovement;
    private CoroutineRunner coroutineRunner;

    private IGameState currentState;
    private Dictionary<GameState, IGameState> states;  

    public void Initialize(PlayerMovement playerMovement, CoroutineRunner coroutineRunner)
    {
        this.playerMovement = playerMovement;
        this.coroutineRunner = coroutineRunner;

        InitializeStates();
        SetState(GameState.Countdown);
    }

    public void Update()
    {
        if (currentState is IUpdatable updatableState)
            updatableState.Update();
    }

    public void SetState(GameState newState)
    {        
        currentState?.Exit();
        currentState = states[newState];

        Debug.Log($"Состояние изменено на: {newState.ToString()} state");
        currentState.Enter();
    }

    private void InitializeStates()
    {
        states = new Dictionary<GameState, IGameState>
        {
            { GameState.Countdown, new CountdownState(this, coroutineRunner) },
            { GameState.Moving, new MovingState(this, playerMovement, coroutineRunner) },
            { GameState.Loss, new LossState(this) },
            { GameState.Victory, new VictoryState(this) }
        };
    }
}
