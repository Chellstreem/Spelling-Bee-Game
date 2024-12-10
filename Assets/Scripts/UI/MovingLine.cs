using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingLine : MonoBehaviour
{
    [SerializeField] RectTransform lineRectTransform;
    private Vector2 originalPosition;
    [SerializeField] float speed = 200f;
    public float endX = -1237;

    private void Start()
    {
        originalPosition = lineRectTransform.anchoredPosition;
    }

    private void Update()
    {
        lineRectTransform.anchoredPosition -= Vector2.right * speed * Time.deltaTime;


        if (lineRectTransform.anchoredPosition.x <= endX)
        {
            lineRectTransform.anchoredPosition = originalPosition;
        }
    }
}
