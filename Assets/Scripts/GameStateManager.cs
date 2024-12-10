using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    [SerializeField] private PlayerMovement playerInput;

    public enum GameState
    {
        Countdown,
        Moving,
        Victory,
        Loss
    }

    private IGameState currentState;
    private Dictionary<GameState, IGameState> states;  

    public void Initialize()
    {
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
            { GameState.Countdown, new CountdownState(this) },
            { GameState.Moving, new MovingState(this, playerInput) },
            { GameState.Loss, new LossState(this) },
            { GameState.Victory, new VictoryState(this) }
        };
    }
}
