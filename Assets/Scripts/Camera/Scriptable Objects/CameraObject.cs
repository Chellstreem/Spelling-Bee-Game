using UnityEngine;

[CreateAssetMenu(fileName = "CameraObject", menuName = "Scriptable Objects/Camera/CameraState")]
public class CameraObject : ScriptableObject
{
    [SerializeField] private CameraType cameraType;
    [SerializeField] private GameObject cameraPrefab;

    public CameraType CameraType => cameraType;
    public GameObject CameraPrefab => cameraPrefab;
}

