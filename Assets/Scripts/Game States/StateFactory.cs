using System.Collections.Generic;
using Zenject;

namespace GameStates
{
    public class StateFactory : IStateFactory
    {
        private readonly DiContainer container;

        public StateFactory(DiContainer container)
        {
            this.container = container;
        }

        public Dictionary<GameState, IGameState> CreateStates()
        {
            return new Dictionary<GameState, IGameState>
        {
            { GameState.Countdown, container.Resolve<CountdownState>() },
            { GameState.Moving, container.Resolve<MovingState>() },
            { GameState.Loss, container.Resolve<LossState>() },
            { GameState.Victory, container.Resolve<VictoryState>() }
        };
        }
    }
}