using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace GameStates
{
    public class GameStateSwitcher : IStateSwitcher
    {   
        private readonly IStateInitializer stateInitializer;
        private IGameState currentState;
        private GameState currentStateName;

        public IGameState CurrentState => currentState;

        private readonly Dictionary<GameState, HashSet<GameState>> allowedTransitions =
            new Dictionary<GameState, HashSet<GameState>>
            {
                { GameState.Countdown, new HashSet<GameState> { GameState.Moving } },
                { GameState.Moving, new HashSet<GameState> { GameState.Loss, GameState.Victory } },
                { GameState.Loss, new HashSet<GameState> { }},
                { GameState.Victory, new HashSet<GameState>{ }}
            };

        public GameStateSwitcher(IStateInitializer stateInitializer)
        {
            this.stateInitializer = stateInitializer;
        }        

        public void SetState(GameState newState)
        {
            if (CanTransitionTo(newState))
            {
                currentState?.Exit();
                currentState = stateInitializer.GetGameState(newState);
                currentStateName = newState;
                
                currentState.Enter();
            }
        }

        private bool CanTransitionTo(GameState state)
        {
            if (currentState == null)
                return true;

            if (allowedTransitions.TryGetValue(currentStateName, out var possibleTransitions))
            {
                return possibleTransitions.Contains(state);
            }

            return false;
        }
    }
}
