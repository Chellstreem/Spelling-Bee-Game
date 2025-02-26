using UnityEngine;
using Zenject;

public class PlayerBehaviour : IEventSubscriber<OnLetterCollision>, IEventSubscriber<OnVictory>, IEventSubscriber<OnBeingDamaged>
{
    private IEventManager eventManager;
    private IPlayerAnimationPlayer animations;
    private IPhysicsModifier physics;

    private readonly Rigidbody rigidBody;
    private readonly BoxCollider boxCollider;

    private readonly Vector3 newColliderCenter = new Vector3(0, 1.3f, 0.38f);
    
    public PlayerBehaviour(IEventManager eventManager, IPlayerAnimationPlayer animations, IPhysicsModifier physics, IPlayerGetter playerGetter)
    {
        this.eventManager = eventManager;
        this.animations = animations;
        this.physics = physics;

        rigidBody = playerGetter.GetPlayer().GetComponent<Rigidbody>();
        boxCollider = playerGetter.GetPlayer().GetComponent<BoxCollider>();

        SubscribeToEvents();
    }    
    
    public void OnEvent(OnLetterCollision eventData) => animations.Flinch();
    
    public void OnEvent(OnVictory eventData) => animations.Dance();    

    public void OnEvent(OnBeingDamaged eventData)
    {
        animations.Die();
        FallDown();
    } 
    
    private void FallDown()
    {
        physics.SetGravity(rigidBody, true);
        physics.SetBoxColliderCenter(boxCollider, newColliderCenter);
    }

    private void SubscribeToEvents()
    {
        eventManager.Subscribe<OnLetterCollision>(this);
        eventManager.Subscribe<OnBeingDamaged>(this);
        eventManager.Subscribe<OnVictory>(this);
    }

    private void UnsubscribeFromEvents()
    {
        eventManager.Unsubscribe<OnLetterCollision>(this);
        eventManager.Unsubscribe<OnBeingDamaged>(this);
        eventManager.Unsubscribe<OnVictory>(this);        
    }
}




