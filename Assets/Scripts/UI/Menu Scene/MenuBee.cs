using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuBee : MonoBehaviour
{
    public bool isLeft;
    private float speed = 25f;
    private float posX = 29f;
    
    void Start()
    {        
        if (transform.position.x >= 29f)
        {
            isLeft = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isLeft)
        {
            transform.position -= Vector3.right * speed * Time.deltaTime;
            if (transform.position.x <= -posX)
                Destroy(gameObject);
        }
        else
        {
            transform.position -= Vector3.left * speed * Time.deltaTime;
            if (transform.position.x >= posX)
                Destroy(gameObject);
        }
    }
}
