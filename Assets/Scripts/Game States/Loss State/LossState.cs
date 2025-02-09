using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameStates
{
    public class LossState : IGameState
    {
        private IStateSwitcher stateSwitcher;

        public LossState(IStateSwitcher stateSwitcher) => this.stateSwitcher = stateSwitcher;

        public void Enter()
        {

        }

        public void Exit() { }
    }
}
