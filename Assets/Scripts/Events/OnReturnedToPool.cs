using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnReturnedToPool : IEvent
{
    public GameObject GameObject { get; private set; }

    public OnReturnedToPool(GameObject obj)
    {
        GameObject = obj;
    }
}
