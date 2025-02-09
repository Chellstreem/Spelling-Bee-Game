using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace GameStates
{
    public class GameStateSwitcher : IStateSwitcher
    {   
        private readonly IStateInitializer stateInitializer;
        public IGameState currentState;

        public IGameState CurrentState => currentState;

        public GameStateSwitcher(IStateInitializer stateInitializer)
        {
            this.stateInitializer = stateInitializer;
        }        

        public void SetState(GameState newState)
        {
            currentState?.Exit();
            currentState = stateInitializer.GetGameState(newState);

            Debug.Log($"Entering {newState.ToString()} state...");
            currentState.Enter();
        }
    }
}
