using System.Collections;
using UnityEngine;

namespace GameStates
{
    public class SafeSubstate : IGameState
    {
        private MovingStateManager substateManager;
        private ICoroutineRunner coroutineRunner;
        private readonly float duration = 2f;

        public SafeSubstate(MovingStateManager substateManager, ICoroutineRunnerHolder runnerHolder)
        {
            this.substateManager = substateManager;
            coroutineRunner = runnerHolder.CoroutineRunner;
        }

        public void Enter()
        {
            Debug.Log("Вход в безопасное состояния");
            coroutineRunner.StartCor(SafetyCoroutine(duration));
        }

        public void Exit() { }

        private IEnumerator SafetyCoroutine(float duration)
        {
            yield return new WaitForSeconds(duration);
            substateManager.SetSubstate(MovingStateSubstate.Interactive);
        }
    }
}
