using System.Collections;
using UnityEngine;


public class CoroutineRunner : MonoBehaviour
{    
    public static CoroutineRunner Instance { get; private set; }

    private void Awake()
    {        
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);  
        }
        else
        {
            Destroy(gameObject); 
        }
    }
    
    public Coroutine StartCustomCoroutine(IEnumerator coroutine)
    {
        return StartCoroutine(coroutine);
    }
}
