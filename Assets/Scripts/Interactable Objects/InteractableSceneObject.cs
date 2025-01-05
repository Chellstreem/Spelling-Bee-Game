
using UnityEngine;

public class InteractableSceneObject : MonoBehaviour
{
    protected virtual void OnPlayerCollision()
    {
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            OnPlayerCollision();
        }        
    }        
}
