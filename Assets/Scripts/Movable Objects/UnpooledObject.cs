using System.Collections;
using UnityEngine;


/// <summary>
/// Класс для объектов, которые изначальео находятся на сцене изначально и не включены в пул
/// </summary>
public class UnpooledObject : MovableObject
{
    private void Start()
    {
        MovingState.OnMovingStarted += StartMoving;
        MovingState.OnMovingStopped += StopMoving;
    }

    public override IEnumerator MoveCoroutine()
    {
        while (true)
        {
            transform.Translate(Vector3.back * GameplayData.speed * Time.deltaTime, Space.World);
            if (transform.position.z <= ThresholdZ)
            {
                StopMoving();
                gameObject.SetActive(false);
            }

            yield return null;
        }
    }

    private void OnDisable()
    {
        MovingState.OnMovingStarted -= StartMoving;
        MovingState.OnMovingStopped -= StopMoving;
    }

    protected override void ReturnToPool()
    {
        Debug.Log("Объект деактивирован");
    }
}
