using UnityEngine;
using Zenject;

public class PlayerAnimation : MonoBehaviour, IEventSubscriber<OnLetterCollision>, IEventSubscriber<OnVictory>, IEventSubscriber<OnDeath>
{
    private IEventManager eventManager;

    private Animator animator;
    private Rigidbody rigidBody;

    int isDead = Animator.StringToHash("isDead");
    int isCollidedHash = Animator.StringToHash("isCollided");
    int isDancing = Animator.StringToHash("isDancing");

    [Inject]
    public void Construct(IEventManager eventManager)
    {
        this.eventManager = eventManager;
    }

    private void Start()
    {
        animator = GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody>();
        
        eventManager.Subscribe<OnLetterCollision>(this);
        eventManager.Subscribe<OnDeath>(this);
        eventManager.Subscribe<OnVictory>(this);
    }

    public void OnEvent(OnLetterCollision eventData) => Flinch();
    
    public void OnEvent(OnVictory eventData) => Dance();    

    public void OnEvent(OnDeath eventData)
    {
        Die();
        ActivateGravity();
    }      

    private void Die() => animator.SetBool(isDead, true);       
    
    private void Flinch() => animator.SetTrigger(isCollidedHash);

    private void Dance() => animator.SetTrigger(isDancing);

    private void ActivateGravity() => rigidBody.useGravity = true;

    private void OnDestroy()
    {
        eventManager.Unsubscribe<OnLetterCollision>(this);
        eventManager.Unsubscribe<OnDeath>(this);
        eventManager.Unsubscribe<OnVictory>(this);
    }
}




