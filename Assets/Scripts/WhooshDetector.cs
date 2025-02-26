using UnityEngine;

public class WhooshDetector : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {        
        if (other.TryGetComponent<IWhooshable>(out var whooshObject))
        {
            whooshObject.OnWhoosh();
        }
    }
}
