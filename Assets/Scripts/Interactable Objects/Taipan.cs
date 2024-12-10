using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Taipan : MonoBehaviour
{
    private Animator animator;
    int isBitten = Animator.StringToHash("isBitten");

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            EventBus.InvokeLoss();
            animator.SetTrigger(isBitten);
        }
    }
}
