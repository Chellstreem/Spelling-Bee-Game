using System.Collections;
using UnityEngine;

namespace GameStates.Moving
{
    public class MissileSubstate : IGameState
    {
        private readonly ISubstateSwitcher<MovingStateSubstate> substateSwitcher;
        private readonly IEventManager eventManager;
        private readonly ICoroutineRunner coroutineRunner;
        private float duration;

        private Coroutine coroutine;        

        public MissileSubstate(ISubstateSwitcher<MovingStateSubstate> substateSwitcher, IEventManager eventManager, ICoroutineRunner coroutineRunner, GameConfig gameConfig)
        {
            this.substateSwitcher = substateSwitcher;
            this.eventManager = eventManager;
            this.coroutineRunner = coroutineRunner;  
            duration = gameConfig.MissileSateDuration;
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
