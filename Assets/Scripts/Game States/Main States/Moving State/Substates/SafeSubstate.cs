using System.Collections;
using UnityEngine;

namespace GameStates.Moving
{
    public class SafeSubstate : IGameState
    {
        private readonly ISubstateSwitcher<MovingStateSubstate> substateSwitcher;
        private readonly ICoroutineRunner coroutineRunner;
        private readonly float duration; // Продолжительность этого подсостояния

        private Coroutine coroutine;        

        public SafeSubstate(ISubstateSwitcher<MovingStateSubstate> substateSwitcher,
            ICoroutineRunner coroutineRunner, GameStateConfig gameStateConfig)
        {
            this.substateSwitcher = substateSwitcher;
            this.coroutineRunner = coroutineRunner;
            duration = gameStateConfig.SafeSubstateDuration;
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
