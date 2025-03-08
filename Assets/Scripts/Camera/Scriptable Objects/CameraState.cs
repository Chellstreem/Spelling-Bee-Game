using Cameras;
using UnityEngine;

[CreateAssetMenu(fileName = "CameraState", menuName = "Scriptable Objects/Camera/CameraState")]
public class CameraState : ScriptableObject
{
    [SerializeField] private CameraStateType camState;
    [SerializeField] private Vector3 cameraPosition;
    [SerializeField] private Vector3 cameraRotation;    

    public CameraStateType CamState => camState;
    public Vector3 CameraPosition => cameraPosition;
    public Vector3 CameraRotation => cameraRotation;
}
