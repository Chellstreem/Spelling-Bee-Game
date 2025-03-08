using System;
using UnityEngine;
using Zenject;

public class PlayerBehaviour : IEventSubscriber<OnLetterCollision>,
    IEventSubscriber<OnVictory>, IEventSubscriber<OnDeath>, IDisposable
{
    private readonly IEventManager eventManager;
    private readonly IPlayerAnimationPlayer animations;
    private readonly IPhysicsModifier physics;
    private readonly IHealth playerHealth;
    private readonly Vector3 newColliderCenter;

    private readonly Rigidbody rigidBody;
    private readonly BoxCollider boxCollider;    

    public PlayerBehaviour(IEventManager eventManager, IPlayerAnimationPlayer animations,
        IPhysicsModifier physics, [Inject(Id = InstantiatedObjectType.Player)] Transform playerTransform,
        IHealth health, PlayerBehaviourConfig config)
    {
        this.eventManager = eventManager;
        this.animations = animations;
        this.physics = physics;
        playerHealth = health;
        newColliderCenter = config.NewColliderCenter;

        rigidBody = playerTransform.GetComponent<Rigidbody>();
        boxCollider = playerTransform.GetComponent<BoxCollider>();

        SubscribeToEvents();
    }

    private void OnLifeChanged(HealthChangeType changeType) => animations.Flinch();    

    public void OnEvent(OnLetterCollision eventData) => animations.Flinch();

    public void OnEvent(OnVictory eventData) => animations.Dance();

    public void OnEvent(OnDeath eventData)
    {
        animations.Die();
        FallDown();
    }

    public void Dispose() => UnsubscribeFromEvents();

    private void FallDown()
    {
        physics.SetGravity(rigidBody, true);
        physics.SetBoxColliderCenter(boxCollider, newColliderCenter);
    }

    private void SubscribeToEvents()
    {
        eventManager.Subscribe<OnLetterCollision>(this);
        eventManager.Subscribe<OnDeath>(this);
        eventManager.Subscribe<OnVictory>(this);
        playerHealth.OnHealthChanged += OnLifeChanged;
    }

    private void UnsubscribeFromEvents()
    {
        eventManager.Unsubscribe<OnLetterCollision>(this);
        eventManager.Unsubscribe<OnDeath>(this);
        eventManager.Unsubscribe<OnVictory>(this);
        playerHealth.OnHealthChanged -= OnLifeChanged;
    }
}




