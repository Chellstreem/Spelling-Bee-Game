using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour, IInitializable
{
    [SerializeField] private GameObject player;
    private Vector3 originalPosition;
    private Vector3 targetPosition;
    private bool isMoving = false;

    private const float moveDistance = 5f;
    private const float moveSpeed = 25f;
    private const float joystickDeadZone = 0.01f;
    private const float positionThreshold = 0.0001f;


    public void Initialize()
    {
        originalPosition = player.transform.position;
        targetPosition = originalPosition;
    }

    public void MovePlayer()
    {
        if (!isMoving) HandleInput();
        if (isMoving) Move();
        if (Input.GetKeyDown(KeyCode.Escape)) EventBus.InvokeLoss();
    }

    private void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            SetTargetPosition(Vector3.up * moveDistance);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) && !isMoving)
        {
            SetTargetPosition(Vector3.zero);
        }

        // Обработка джойстика
        float joystickVertical = Input.GetAxis("Vertical");

        if (Mathf.Abs(joystickVertical) > joystickDeadZone)
        {
            if (joystickVertical > 0)
            {
                SetTargetPosition(Vector3.up * moveDistance);
            }
            else if (joystickVertical < 0)
            {
                SetTargetPosition(Vector3.zero);
            }
        }
    }

    private void SetTargetPosition(Vector3 offset)
    {
        targetPosition = originalPosition + offset;
        isMoving = true;
    }

    private void Move()
    {
        if ((player.transform.position - targetPosition).sqrMagnitude < positionThreshold)
        {
            player.transform.position = targetPosition;
            isMoving = false;
        }
        else
            player.transform.position = Vector3.MoveTowards(player.transform.position, targetPosition, moveSpeed * Time.deltaTime);

    }
}
