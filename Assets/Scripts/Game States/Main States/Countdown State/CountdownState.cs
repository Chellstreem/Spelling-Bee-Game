using System.Collections;
using UnityEngine;

namespace GameStates
{
    public class CountdownState : IGameState
    {
        private IStateSwitcher stateSwitcher;
        private IEventManager eventManager;
        private ICoroutineRunner coroutineRunner;
        
        private readonly int count;
        private readonly int fontSize;
        private readonly int fontSizeDecrement;
        private readonly int finalFontSize;        

        public CountdownState(IStateSwitcher stateSwitcher, IEventManager eventManager, ICoroutineRunner runner, GameStateConfig config)
        {
            this.stateSwitcher = stateSwitcher;
            this.eventManager = eventManager;
            coroutineRunner = runner;

            count = config.Count;
            fontSize = config.FontSize;
            fontSizeDecrement = config.FontSizeDecrement;
            finalFontSize = config.FinalFontSize;
        }

        public void Enter()
        {
            eventManager.Publish(new OnCountdownStateEnter());
            coroutineRunner.StartCor(CountDown(count, fontSize, finalFontSize));            
        }

        private IEnumerator CountDown(int count, int fontSize, int finalFontSize)
        {
            while (count >= 0)
            {
                eventManager.Publish(new OnCountdownTick(count, fontSize, finalFontSize));
                yield return new WaitForSeconds(1f);
                count--;
                fontSize -= fontSizeDecrement;
            }

            stateSwitcher.SetState(GameState.Moving);
        }

        public void Exit()
        {            
            eventManager.Publish(new OnCountdownStateExit());
        }
    }
}