using System.Collections;
using UnityEngine;

namespace GameStates.Moving
{
    public class SafeSubstate : IGameState
    {
        private readonly ISubstateSwitcher<MovingStateSubstate> substateSwitcher;
        private readonly ICoroutineRunner coroutineRunner;

        private Coroutine coroutine;
        private readonly float duration = 1.5f;

        public SafeSubstate(ISubstateSwitcher<MovingStateSubstate> substateSwitcher, ICoroutineRunnerHolder runnerHolder)
        {
            this.substateSwitcher = substateSwitcher;
            coroutineRunner = runnerHolder.CoroutineRunner;
        }

        public void Enter()
        {
            Debug.Log("Entering Safe State...");
            coroutine = coroutineRunner.StartCor(SafetyCoroutine(duration));
        }

        public void Exit()
        {
            Debug.Log("Exiting Safe State...");
            StopSafetyCoroutine();            
        }

        private IEnumerator SafetyCoroutine(float duration)
        {
            yield return new WaitForSeconds(duration);
            substateSwitcher.SetSubstate(MovingStateSubstate.Interactive);
        }

        private void StopSafetyCoroutine()
        {
            if (coroutine != null)
            {
                coroutineRunner.StopCor(coroutine);
                coroutine = null;
            }
        }         
    }
}
