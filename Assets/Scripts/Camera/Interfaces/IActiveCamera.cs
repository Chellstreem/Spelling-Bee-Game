using System;
using UnityEngine;

public interface IActiveCamera
{
    public GameObject ActiveCamera { get; }
    public event Action OnCameraSwitched;
}
