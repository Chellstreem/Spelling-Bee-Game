using UnityEngine;
using Zenject;

public class PlayerCanvas : Billboard
{

    public void Start()
    {
        UpdateTargetCamera();
    }      

    private void OnEnable() => activeCamera.OnCameraSwitched += UpdateTargetCamera;

    private void OnDisable() => activeCamera.OnCameraSwitched -= UpdateTargetCamera;        
}
