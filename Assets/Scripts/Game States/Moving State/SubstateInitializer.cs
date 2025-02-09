using System.Collections.Generic;
using Zenject;

namespace GameStates.Moving
{
    public class SubstateInitializer : ISubstateInitializer<MovingStateSubstate>
    {        
        private readonly DiContainer container;
        private Dictionary<MovingStateSubstate, IGameState> subStates;

        public SubstateInitializer(DiContainer container)
        {           
            this.container = container;            
        }

        public void InitializeSubstates()
        {
            subStates = new Dictionary<MovingStateSubstate, IGameState>
        {
            { MovingStateSubstate.Safe, container.Resolve<SafeSubstate>() },
            { MovingStateSubstate.Interactive, container.Resolve<InteractiveSubstate>() },
            { MovingStateSubstate.Missile, container.Resolve<MissileSubstate>() }
        };
        }

        public IGameState GetSubstate(MovingStateSubstate state)
        {
            return subStates.TryGetValue(state, out var subState) ? subState : null;
        }
    }
}
