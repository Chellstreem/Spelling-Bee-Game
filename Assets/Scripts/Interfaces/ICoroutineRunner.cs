using System.Collections;
using UnityEngine;

public interface ICoroutineRunner 
{
    public Coroutine StartCor(IEnumerator coroutine);

    public void StopCor(Coroutine coroutine);    
}
