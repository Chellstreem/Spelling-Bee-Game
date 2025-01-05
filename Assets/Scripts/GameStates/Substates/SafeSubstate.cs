using UnityEngine;
using System.Collections;

public class SafeSubstate : IGameState
{
    private MovingState movingState;
    private ICoroutineRunner coroutineRunner;
    private int safetyDuration;

    public SafeSubstate(MovingState movingState, ICoroutineRunner coroutineRunner, int safetyDuration)
    {
        this.movingState = movingState;
        this.coroutineRunner = coroutineRunner;
        this.safetyDuration = safetyDuration;
    }

    public void Enter()
    {
        Debug.Log("Вход в безопасное состояние.");
        coroutineRunner.StartCor(SafetyCountdown(safetyDuration));
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