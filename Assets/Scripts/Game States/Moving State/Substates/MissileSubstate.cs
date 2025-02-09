using System.Collections;
using UnityEngine;

namespace GameStates.Moving
{
    public class MissileSubstate : IGameState
    {
        private ISubstateSwitcher<MovingStateSubstate> substateSwitcher;
        private IEventManager eventManager;
        private ICoroutineRunner coroutineRunner;        

        private Coroutine coroutine;
        private readonly float duration = 2f;

        public MissileSubstate(ISubstateSwitcher<MovingStateSubstate> substateSwitcher, IEventManager eventManager, ICoroutineRunnerHolder runnerHolder)
        {
            this.substateSwitcher = substateSwitcher;
            this.eventManager = eventManager;
            coroutineRunner = runnerHolder.CoroutineRunner;          
        }

        public void Enter()
        {
            Debug.Log("Entering Missile State...");
            eventManager.Publish(new OnMissileStateEnter());
            StartMissileCoroutine();
        }

        public void Exit()
        {
            Debug.Log("Exiting Missile State...");
            eventManager.Publish(new OnMissileStateExit());
            StopMissileCoroutine();
        }

        private IEnumerator MissileCoroutine(float duration)
        {
            yield return new WaitForSeconds(duration);
            substateSwitcher.SetSubstate(MovingStateSubstate.Safe);
        }

        private void StartMissileCoroutine()
        {
            coroutine = coroutineRunner.StartCor(MissileCoroutine(duration));
        }

        private void StopMissileCoroutine()
        {
            if (coroutine != null)
            {
                coroutineRunner.StopCor(coroutine);
                coroutine = null;
            }
        }
    }
}
