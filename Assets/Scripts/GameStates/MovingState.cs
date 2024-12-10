using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MovingState : IGameState, IUpdatable
{
    private GameStateManager gameStateManager;
    private PlayerMovement playerInput;
    private const int safetyDuration = 2;

    public IGameState safeSubstate;
    public IGameState unsafeSubstate;
    private IGameState currentSubstate;

    public static event Action OnMovingStarted;
    public static event Action OnMovingStopped;

    public MovingState(GameStateManager gameStateManager, PlayerMovement playerInput)
    {
        this.gameStateManager = gameStateManager;
        this.playerInput = playerInput;

        safeSubstate = new SafeSubstate(this, safetyDuration);
        unsafeSubstate = new UnsafeSubstate(this);
    }

    public void Enter()
    {
        OnMovingStarted?.Invoke();
        SetSubstate(unsafeSubstate);

        EventBus.OnLoss += OnLoss;
        EventBus.OnVictory += OnVictory;
    }

    public void Exit()
    {
        OnMovingStopped?.Invoke();
        currentSubstate?.Exit();

        EventBus.OnLoss -= OnLoss;
        EventBus.OnVictory -= OnVictory;
    }

    public void Update() => playerInput.MovePlayer();

    public void SetSubstate(IGameState newSubstate)
    {
        currentSubstate?.Exit();
        currentSubstate = newSubstate;
        currentSubstate.Enter();
    }

    private void OnVictory() => gameStateManager.SetState(GameStateManager.GameState.Victory);

    private void OnLoss() => gameStateManager.SetState(GameStateManager.GameState.Loss);


    /// <summary>
    /// Безопасное подсостояние на небольшое время, которое активируется, когда игрок заполняет слово. 
    /// </summary>
    public class SafeSubstate : IGameState
    {
        private MovingState movingState;
        private int safetyDuration;

        public SafeSubstate(MovingState movingState, int safetyDuration)
        {
            this.movingState = movingState;
            this.safetyDuration = safetyDuration;

        }

        public void Enter()
        {
            Debug.Log("Вход в безопасное состояние.");
            CoroutineRunner.Instance.StartCustomCoroutine(SafetyCountdown(safetyDuration));
        }

        private IEnumerator SafetyCountdown(int duration)
        {
            while (duration > 0)
            {
                yield return new WaitForSeconds(1f);
                duration--;
            }

            movingState.SetSubstate(movingState.unsafeSubstate);
        }

        public void Exit() { }
    }

    /// <summary>
    /// Состояние, в котором игрок может сталкиваться с обьектами
    /// </summary>
    public class UnsafeSubstate : IGameState
    {
        private MovingState movingState;

        public static event Action OnUnsafeSubstateEnter;
        public static event Action OnUnsafeSubstateExit;

        public UnsafeSubstate(MovingState movingState) => this.movingState = movingState;

        public void Enter()
        {
            Debug.Log("Вход в опасное состояние.");
            EventBus.OnWordCompleted += OnWordCompleted;

            OnUnsafeSubstateEnter?.Invoke();
        }

        private void OnWordCompleted() => movingState.SetSubstate(movingState.safeSubstate);

        public void Exit()
        {
            EventBus.OnWordCompleted -= OnWordCompleted;
            OnUnsafeSubstateExit?.Invoke();
        }
    }
}
