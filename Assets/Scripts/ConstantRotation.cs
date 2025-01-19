using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstantRotation : MonoBehaviour
{
    private float speed = 120;
    public float Speed => speed;    
    
    void Update()
    {
        transform.Rotate(Vector3.up, Speed * Time.deltaTime);
    }
}
