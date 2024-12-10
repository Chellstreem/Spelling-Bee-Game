using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MovableObject
{
    private void OnEnable()
    {
        StartMoving();

        EventBus.OnLoss += StopMoving;
        EventBus.OnVictory += StopMoving;
        EventBus.OnWordCompleted += ReturnToPool;
    }

    private void OnDisable()
    {
        StopMoving();

        EventBus.OnLoss -= StopMoving;
        EventBus.OnVictory -= StopMoving;
        EventBus.OnWordCompleted -= ReturnToPool;
    }

    private void OnDestroy()
    {
        EventBus.OnLoss -= StopMoving;
        EventBus.OnVictory -= StopMoving;
        EventBus.OnWordCompleted -= ReturnToPool;
    }    

    private void OnVictory() => StopMoving();
}
