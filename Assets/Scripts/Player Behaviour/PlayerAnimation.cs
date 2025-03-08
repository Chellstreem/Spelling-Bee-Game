using UnityEngine;
using Zenject;

public class PlayerAnimation : IPlayerAnimationPlayer
{
    private readonly Animator animator;    

    private readonly int isDead = Animator.StringToHash("isDead");
    private readonly int isCollidedHash = Animator.StringToHash("isCollided");
    private readonly int isDancing = Animator.StringToHash("isDancing");

    public PlayerAnimation([Inject(Id = InstantiatedObjectType.Player)] Transform playerTransform)
    {
        animator = playerTransform.GetComponent<Animator>();      
    }

    public void Die() => animator.SetBool(isDead, true);

    public void Flinch() => animator.SetTrigger(isCollidedHash);

    public void Dance() => animator.SetTrigger(isDancing);
}
