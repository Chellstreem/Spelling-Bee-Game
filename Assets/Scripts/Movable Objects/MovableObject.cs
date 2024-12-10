using System.Collections;
using UnityEngine;

public class MovableObject : MonoBehaviour
{
    private Coroutine moveCoroutine;
    protected const float ThresholdZ = -56f;

    public virtual IEnumerator MoveCoroutine()
    {
        while (true)
        {
            transform.Translate(Vector3.back * GameplayData.speed * Time.deltaTime, Space.World);
            if (transform.position.z <= ThresholdZ)
            {
                StopMoving();
                ReturnToPool();
            }

            yield return null;
        }
    }

    public void StartMoving()
    {
        if (moveCoroutine == null) moveCoroutine = StartCoroutine(MoveCoroutine());
    }

    public void StopMoving()
    {
        if (moveCoroutine != null)
            StopCoroutine(moveCoroutine);
        moveCoroutine = null;
    }

    protected virtual void ReturnToPool() => EventBus.InvokeReturnedToPool(gameObject);
}
