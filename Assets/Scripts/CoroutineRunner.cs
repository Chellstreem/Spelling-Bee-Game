using System;
using System.Collections;
using UnityEngine;


public class CoroutineRunner : MonoBehaviour, ICoroutineRunner
{
    public Coroutine StartCor(IEnumerator coroutine)
    {
        if (coroutine == null) throw new ArgumentNullException(nameof(coroutine));
        return StartCoroutine(coroutine);
    }

    public void StopCor(Coroutine coroutine)
    {
        if (coroutine != null)
            StopCoroutine(coroutine);
    }
}
