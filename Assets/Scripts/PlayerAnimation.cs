using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour, IInitializable
{
    [SerializeField] private Animator animator;
    private Rigidbody rigidBody;

    int isDead = Animator.StringToHash("isDead");
    int isCollidedHash = Animator.StringToHash("isCollided");
    int isDancing = Animator.StringToHash("isDancing");

    public void Initialize()
    {
        rigidBody = animator.gameObject.GetComponent<Rigidbody>();

        EventBus.OnLetterCollision += Flinch;
        EventBus.OnLoss += OnLoss;
        EventBus.OnVictory += OnVictory;
    }

    private void OnLoss()
    {
        Die();
        ActivateGravity();
    }

    private void OnVictory() => Dance();    

    private void Die() => animator.SetBool(isDead, true);       
    
    private void Flinch(string letter) => animator.SetTrigger(isCollidedHash);

    private void Dance() => animator.SetTrigger(isDancing);

    private void ActivateGravity() => rigidBody.useGravity = true;

    private void OnDestroy()
    {
        EventBus.OnLetterCollision -= Flinch;
        EventBus.OnLoss -= OnLoss;
        EventBus.OnVictory -= OnVictory;
    }
}




