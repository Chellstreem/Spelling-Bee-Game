using System;

public interface IInput
{
    public event Action ClickUp;
    public event Action ClickDown;
    public event Action ClickEscape;    
}
