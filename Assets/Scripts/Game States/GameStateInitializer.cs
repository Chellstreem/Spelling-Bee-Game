using System.Collections.Generic;
using Zenject;

namespace GameStates
{
    public class GameStateInitializer : IStateInitializer
    {
        private readonly DiContainer container;
        private Dictionary<GameState, IGameState> gameStates;

        public GameStateInitializer(DiContainer container)
        {
            this.container = container;
        }

        public void InitializeStates()
        {
            gameStates = new Dictionary<GameState, IGameState>()
            {
            { GameState.Countdown, container.Resolve<CountdownState>() },
            { GameState.Moving, container.Resolve<MovingState>() },
            { GameState.Loss, container.Resolve<LossState>() },
            { GameState.Victory, container.Resolve<VictoryState>() }
        };
        }

        public IGameState GetGameState(GameState gameState)
        {
            return gameStates.TryGetValue(gameState, out IGameState StateObj) ? StateObj : null;
        }
    }
}