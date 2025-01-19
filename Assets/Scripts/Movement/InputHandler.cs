using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : IInputHandler
{
    private IVerticalMovement mover;
    private IDeathInvoker deathInvoker;

    private const float joystickDeadZone = 0.01f;
    
    public InputHandler(IVerticalMovement mover, IDeathInvoker deathInvoker)
    {
        this.mover = mover;
        this.deathInvoker = deathInvoker;
    }

    public void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            mover.GoUp();
        }            
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            mover.GoDown();
        }            

        float joystickVertical = Input.GetAxis("Vertical");

        if (Mathf.Abs(joystickVertical) > joystickDeadZone)
        {
            if (joystickVertical > 0)
                mover.GoUp();
            else if (joystickVertical < 0)
                mover.GoDown();
        }

        if (Input.GetKeyDown(KeyCode.Escape)) deathInvoker.InvokeDeath();
    }
}
