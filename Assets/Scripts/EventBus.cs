using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventBus
{        
    public static event Action<string> OnLetterCollision;
    public static void InvokeLetterCollision(string value) => OnLetterCollision?.Invoke(value);

    //

    public static event Action<bool> OnLetterChecked;
    public static void InvokeLetterChecked(bool isCorrect) => OnLetterChecked?.Invoke(isCorrect);

    //

    public static event Action OnWordCompleted;
    public static void InvokeWordCompleted() => OnWordCompleted?.Invoke();

    //

    public static event Action OnVictory;
    public static void InvokeVictory() => OnVictory?.Invoke();

    //

    public static event Action OnLoss;
    public static void InvokeLoss() => OnLoss?.Invoke();

    //
    
    public static event Action<GameObject> OnObjectReturnedToPool;
    public static void InvokeReturnedToPool(GameObject obj) => OnObjectReturnedToPool?.Invoke(obj);
}
