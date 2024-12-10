using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Vector3 targetPosition;
    private Quaternion targetRotation;
    private float rotationThreshhold = 0.06f;
    private Vector3 startPosition = new Vector3(3.65f, 3.31f, -40f);
    private Vector3 targetPositionOffset = new Vector3(-3.5f, 0, -4f);
    private Vector3 originalPosition;

    private float zoomInDuration = 0.6f;
    private float tiltAngle = 13f;
    private bool isZooming;
    private bool isUnzooming;

    void Start()
    {
        originalPosition = transform.position; //save camera position        
        targetPosition = transform.position + targetPositionOffset; // save target position
        targetRotation = Quaternion.Euler(transform.rotation.eulerAngles.x + tiltAngle, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
        transform.position = startPosition; // move camera closer

       
    }

    private void MoveCloser()
    {
        isZooming = true;
    }

    private void OnGameStarted()
    {
        isUnzooming = true;
    }

    private void Update()
    {
        if (isZooming)
        {
            transform.position = Vector3.Lerp(transform.position, targetPosition, zoomInDuration * Time.deltaTime);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, zoomInDuration * Time.deltaTime);
        }
        if (Quaternion.Angle(transform.rotation, targetRotation) < rotationThreshhold && Vector3.Distance(transform.position, targetPosition) < rotationThreshhold)
        {
            isZooming = false;
        }
        if (isUnzooming)
            transform.position = Vector3.Lerp(transform.position, originalPosition, (zoomInDuration + 1.3f) * Time.deltaTime);
        if (Vector3.Distance(transform.position, originalPosition) < rotationThreshhold)
            isUnzooming = false;
    }
    private void OnDestroy()
    {
    }
        
}
