using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICoroutineRunner 
{
    public Coroutine StartCor(IEnumerator coroutine);

    public void StopCor(Coroutine coroutine);    
}
