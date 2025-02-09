using UnityEngine;

namespace GameStates.Moving
{
    public class InteractiveSubstate : IGameState, IEventSubscriber<OnWordCompleted>, IEventSubscriber<OnOrbMissileCollected>
    {
        private readonly ISubstateSwitcher<MovingStateSubstate> substateSwitcher;
        private readonly IEventManager eventManager;        

        public InteractiveSubstate(ISubstateSwitcher<MovingStateSubstate> substateSwitcher, IEventManager eventManager)
        {
            this.substateSwitcher = substateSwitcher;
            this.eventManager = eventManager;           
        }

        public void Enter()
        {
            Debug.Log("Entering Interactive State...");            
            eventManager.Publish(new OnInteractiveSubstateEnter());
            SubscribeToEvents();
        }

        public void Exit()
        {
            Debug.Log("Exiting Interactive State...");            
            eventManager.Publish(new OnInteractiveSubstateExit());
            UnsubscribeFromEvents();
        }

        public void OnEvent(OnWordCompleted eventData)
        {
            substateSwitcher.SetSubstate(MovingStateSubstate.Safe);
        }

        public void OnEvent(OnOrbMissileCollected eventData)
        {
            substateSwitcher.SetSubstate(MovingStateSubstate.Missile);
        }

        private void SubscribeToEvents()
        {
            eventManager.Subscribe<OnWordCompleted>(this);
            eventManager.Subscribe<OnOrbMissileCollected>(this);
        }

        private void UnsubscribeFromEvents()
        {
            eventManager.Unsubscribe<OnWordCompleted>(this);
            eventManager.Unsubscribe<OnOrbMissileCollected>(this);
        }
    }
}
