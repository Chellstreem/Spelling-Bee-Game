using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameStates
{
    public class VictoryState : IGameState
    {
        private IStateSwitcher stateSwitcher;

        public VictoryState(IStateSwitcher stateSwitcher) => this.stateSwitcher = stateSwitcher;

        public void Enter() { }

        public void Exit() { }
    }
}
