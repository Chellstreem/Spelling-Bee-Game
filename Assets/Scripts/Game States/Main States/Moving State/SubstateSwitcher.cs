using System.Collections.Generic;
using UnityEngine;


namespace GameStates.Moving
{
    public class SubstateSwitcher : ISubstateSwitcher<MovingStateSubstate>
    {      
        private readonly ISubstateInitializer<MovingStateSubstate> substateInitializer;
        private IGameState currentSubstate;
        private MovingStateSubstate currentSubstateType;

        private readonly Dictionary<MovingStateSubstate, HashSet<MovingStateSubstate>> allowedTransitions =
            new Dictionary<MovingStateSubstate, HashSet<MovingStateSubstate>>
            {
                { MovingStateSubstate.Interactive, new HashSet<MovingStateSubstate> { MovingStateSubstate.Missile, MovingStateSubstate.Safe } },
                { MovingStateSubstate.Safe, new HashSet<MovingStateSubstate> { MovingStateSubstate.Interactive } },
                { MovingStateSubstate.Missile, new HashSet<MovingStateSubstate> { MovingStateSubstate.Safe } }
            };

        public SubstateSwitcher(ISubstateInitializer<MovingStateSubstate> substateInitializer)
        {
            this.substateInitializer = substateInitializer;                
        }

        public void SetSubstate(MovingStateSubstate substate)
        {            
            if (CanTransitionTo(substate))
            {                
                currentSubstate?.Exit();
                currentSubstate = substateInitializer.GetSubstate(substate);
                currentSubstateType = substate;
                currentSubstate.Enter();
            }
        }

        public void ExitCurrentSubstate()
        {
            currentSubstate?.Exit();
            currentSubstate = null;
        }

        private bool CanTransitionTo(MovingStateSubstate substate)
        {
            if (currentSubstate == null)
                return true;            
            
            if (allowedTransitions.TryGetValue(currentSubstateType, out var possibleTransitions))
            {
                return possibleTransitions.Contains(substate);
            }

            return false;
        }
    }
}

