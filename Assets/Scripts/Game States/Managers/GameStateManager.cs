using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace GameStates
{
    public class GameStateManager : ITickable, IStateSwitcher
    {
        private IGameState currentState;
        private IStateFactory stateFactory;
        private Dictionary<GameState, IGameState> states;

        public GameStateManager(IStateFactory stateFactory)
        {
            this.stateFactory = stateFactory;
        }

        [Inject]
        private void InitializeStates()
        {
            states = stateFactory.CreateStates();
            SetState(GameState.Countdown);
        }

        public void Tick()
        {
            if (currentState is IUpdatable updatableState)
                updatableState.Update();
        }

        public void SetState(GameState newState)
        {
            currentState?.Exit();
            currentState = states[newState];

            Debug.Log($"Состояние изменено на: {newState.ToString()} state");
            currentState.Enter();
        }
    }
}
