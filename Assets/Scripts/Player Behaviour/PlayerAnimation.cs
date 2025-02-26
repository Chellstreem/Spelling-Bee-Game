using UnityEngine;

public class PlayerAnimation : IPlayerAnimationPlayer
{
    private readonly Animator animator;

    private readonly int isDead = Animator.StringToHash("isDead");
    private readonly int isCollidedHash = Animator.StringToHash("isCollided");
    private readonly int isDancing = Animator.StringToHash("isDancing");

    public PlayerAnimation(IPlayerGetter playerGetter)
    {
        animator = playerGetter.GetPlayer().GetComponent<Animator>();      
    }

    public void Die() => animator.SetBool(isDead, true);

    public void Flinch() => animator.SetTrigger(isCollidedHash);

    public void Dance() => animator.SetTrigger(isDancing);
}
