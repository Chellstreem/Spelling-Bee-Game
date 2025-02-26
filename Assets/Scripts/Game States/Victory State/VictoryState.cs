using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameStates
{
    public class VictoryState : IGameState
    {
        private IStateSwitcher stateSwitcher;
        private IEventManager eventManager;

        public VictoryState(IStateSwitcher stateSwitcher, IEventManager eventManager)
        {
            this.stateSwitcher = stateSwitcher;
            this.eventManager = eventManager;
        }

        public void Enter()
        {
            eventManager.Publish(new OnVictoryStateEnter());
        }

        public void Exit() { }
    }
}
