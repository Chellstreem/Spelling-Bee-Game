using UnityEngine;
using System.Collections;

public class Background : MovableObject
{    
    private Vector3 startPosition;

    void Start()
    {        
        startPosition = transform.position;

        MovingState.OnMovingStarted += StartMoving;
        MovingState.OnMovingStopped += StopMoving;
    }    

    public override IEnumerator MoveCoroutine()
    {
        while (true)
        {
            transform.Translate(Vector3.right * GameplayData.speed * Time.deltaTime);

            if (transform.position.z < ThresholdZ)
            {
                transform.position = startPosition;
            }

            yield return null;
        }
    }

    private void OnDestroy()
    {
        MovingState.OnMovingStarted -= StartMoving;
        MovingState.OnMovingStopped -= StopMoving;
    }
}
