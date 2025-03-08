using UnityEngine;

[CreateAssetMenu(fileName = "CameraСonfig", menuName = "Scriptable Objects/Camera/Camera Config")]
public class CameraConfig : ScriptableObject
{
    [SerializeField] private CameraObject[] cameraObjects;
    [SerializeField] private CameraState[] states;
    [SerializeField] private float cameraShakeIntensity;
    [SerializeField] private float cameraShakeDuration;    
    
    public CameraObject[] CameraObjects => cameraObjects;
    public CameraState[] States => states;
    public float CameraShakeIntensity => cameraShakeIntensity;
    public float CameraShakeDuration => cameraShakeDuration;
}
