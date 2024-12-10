using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NonInteractableObject : MovableObject
{
    private void OnEnable()
    {
        StartMoving();

        EventBus.OnLoss += StopMoving;
        EventBus.OnVictory += StopMoving;
        
    }

    private void OnDisable()
    {
        StopMoving();   

        EventBus.OnLoss -= StopMoving;
        EventBus.OnVictory -= StopMoving;
    }

    private void OnDestroy()
    {
        EventBus.OnLoss -= StopMoving;
        EventBus.OnVictory -= StopMoving;
    }
}
