using System;
using UnityEngine;

public class UnsafeSubstate : IGameState
{
    private MovingState movingState;

    public static event Action OnUnsafeSubstateEnter;
    public static event Action OnUnsafeSubstateExit;

    public UnsafeSubstate(MovingState movingState) => this.movingState = movingState;

    public void Enter()
    {
        Debug.Log("Вход в опасное состояние.");
        EventManager.OnWordCompleted += OnWordCompleted;

        OnUnsafeSubstateEnter?.Invoke();
    }

    private void OnWordCompleted()
    {
        movingState.SetSubstate(movingState.safeSubstate);
    }     

    public void Exit()
    {
        EventManager.OnWordCompleted -= OnWordCompleted;
        OnUnsafeSubstateExit?.Invoke();
    }
}
