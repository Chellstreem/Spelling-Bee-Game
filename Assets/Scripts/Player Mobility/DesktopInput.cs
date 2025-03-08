using UnityEngine;
using System;

namespace PlayerMobility
{
    public class DesktopInput : IInput, IInputHandler
    {
        public event Action ClickUp;
        public event Action ClickDown;
        public event Action ClickEscape;

        private readonly float joystickDeadZone = 0.001f;

        public void HandleInput()
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                ClickUp?.Invoke();
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                ClickDown?.Invoke();
            }

            float joystickVertical = Input.GetAxis("Vertical");

            if (Mathf.Abs(joystickVertical) > joystickDeadZone)
            {
                if (joystickVertical > 0)
                {
                    ClickUp?.Invoke();
                }
                else if (joystickVertical < 0)
                {
                    ClickDown?.Invoke();
                }
            }

            if (Input.GetKeyDown(KeyCode.Escape))
                ClickEscape?.Invoke();
        }
    }
}
