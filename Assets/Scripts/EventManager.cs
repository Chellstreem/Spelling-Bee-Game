using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager
{        
    public static event Action<string, Vector3> OnLetterCollision;
    public static void InvokeLetterCollision(string value, Vector3 position) => OnLetterCollision?.Invoke(value, position);

    //

    public static event Action<bool, Vector3> OnLetterChecked;
    public static void InvokeLetterChecked(bool isCorrect, Vector3 position) => OnLetterChecked?.Invoke(isCorrect, position);

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

    //

    public static event Action<ParticleObject.ParticleType, Vector3> OnPartcilePlay;
    public static void InvokeOnParticlePlay(ParticleObject.ParticleType particleType, Vector3 position ) => OnPartcilePlay?.Invoke(particleType, position);
}
