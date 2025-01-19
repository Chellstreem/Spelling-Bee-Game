using System;
using System.Collections;
using UnityEngine;
using Zenject;

namespace GameStates
{
    public class CountdownState : IGameState
    {
        private IStateSwitcher stateSwitcher;
        private ICoroutineRunner coroutineRunner;
        private SceneUIStore sceneUIStore;

        private const int Count = 3;
        private const int GoFontSize = 350; // Размер шрифта для надписи Go!
        private const int FontSizeDecrement = 45; // Насколько уменьшается размер шрифта при каждом тике
        private int fontSize = 320;
        
        public CountdownState(IStateSwitcher stateSwitcher, ICoroutineRunnerHolder runnertHolder, SceneUIStore sceneUIStore)
        {
            this.stateSwitcher = stateSwitcher;
            coroutineRunner = runnertHolder.CoroutineRunner;
            this.sceneUIStore = sceneUIStore;
        }

        public void Enter()
        {
            coroutineRunner.StartCor(CountDown(Count, fontSize, GoFontSize));
        }

        private IEnumerator CountDown(int count, int fontSize, int goFontSize)
        {
            sceneUIStore.ActivateCountdownBar();
            while (count >= 0)
            {
                sceneUIStore.UpdateCountdown(count, fontSize, goFontSize);
                yield return new WaitForSeconds(1f);
                count--;
                fontSize -= FontSizeDecrement;
            }

            sceneUIStore.DeactivateCountdownBar();
            ChangeState(GameState.Moving);
        }

        private void ChangeState(GameState gameState) => stateSwitcher.SetState(gameState);

        public void Exit() { }
    }
}
