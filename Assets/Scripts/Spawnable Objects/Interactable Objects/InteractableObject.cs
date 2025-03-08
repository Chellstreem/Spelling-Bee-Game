using UnityEngine;
using Zenject;

namespace InteractableObjects
{
    public abstract class InteractableObject : MonoBehaviour
    {
        protected abstract void OnPlayerCollision();        

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                OnPlayerCollision();
            }
        }
    }
}
