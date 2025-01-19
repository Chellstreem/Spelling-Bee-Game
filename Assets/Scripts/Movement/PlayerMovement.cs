using System.Collections;
using UnityEngine;

public class PlayerMovement : IHorizontalMovement, IVerticalMovement, IDeathInvoker
{
    private IEventManager eventManager;
    private GameObject player;
    private float moveDistance;
    private float moveSpeed;
    private float positionThreshold;
    private Vector3 originalPosition;
    
    private Vector3 targetPosition;
    private bool isMoving;

    public PlayerMovement(GameConfig gameConfig, IEventManager eventManager, IPlayerHolder playerHolder)
    {
        this.eventManager = eventManager;
        moveDistance = gameConfig.MoveDistance;
        moveSpeed = gameConfig.MoveSpeed;
        positionThreshold = gameConfig.PositionThreshold;
        originalPosition = gameConfig.PlayerPosition;
        player = playerHolder.Player;              
    }

    public void GoUp() => SetTargetPosition(Vector3.up * moveDistance);

    public void GoDown() => SetTargetPosition(Vector3.zero);    

    public void Move()
    {
        if (isMoving)
        {
            if ((player.transform.position - targetPosition).sqrMagnitude < positionThreshold)
            {
                player.transform.position = targetPosition;
                isMoving = false;
            }
            else
            {
                player.transform.position = Vector3.MoveTowards(player.transform.position,
                    targetPosition, moveSpeed * Time.deltaTime);
            }                
        }
    }

    public void InvokeDeath() => eventManager.Publish(new OnDeath());

    private void SetTargetPosition(Vector3 offset)
    {
        targetPosition = originalPosition + offset;
        isMoving = true;
    }
}
