using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : IInputHandler
{
    private PlayerMovement playerMovement;
    private const float joystickDeadZone = 0.01f;
    
    public InputHandler(PlayerMovement playerMovement)
    {
        this.playerMovement = playerMovement;
    }

    public void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            playerMovement.SetUpperTargetPosition();
        }            
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            playerMovement.SetLowerTargetPosition();
        }            

        float joystickVertical = Input.GetAxis("Vertical");

        if (Mathf.Abs(joystickVertical) > joystickDeadZone)
        {
            if (joystickVertical > 0)
                playerMovement.SetUpperTargetPosition();
            else if (joystickVertical < 0)
                playerMovement.SetLowerTargetPosition();
        }

        if (Input.GetKeyDown(KeyCode.Escape)) playerMovement.InvokeLoss();
    }
}
