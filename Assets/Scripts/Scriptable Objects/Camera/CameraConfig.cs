using UnityEngine;

[CreateAssetMenu(fileName = "CameraStateCollection", menuName = "Scriptable Objects/CameraStateCollection")]
public class CameraConfig : ScriptableObject
{
    [SerializeField] private GameObject cameraPrefab;
    [SerializeField] private CameraState[] states;
    [SerializeField] private float cameraShakeIntensity;
    [SerializeField] private float cameraShakeDuration;
    
    public GameObject CameraPrefab => cameraPrefab;
    public CameraState[] States => states;
    public float CameraShakeIntensity => cameraShakeIntensity;
    public float CameraShakeDuration => cameraShakeDuration;
}
