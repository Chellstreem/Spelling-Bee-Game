using Camera;
using UnityEngine;

[CreateAssetMenu(fileName = "CameraState", menuName = "Scriptable Objects/CameraState")]
public class CameraState : ScriptableObject
{
    [SerializeField] private Camera.CameraStateType camState;
    [SerializeField] private Vector3 cameraPosition;
    [SerializeField] private Vector3 cameraRotation;    

    public Camera.CameraStateType CamState => camState;
    public Vector3 CameraPosition => cameraPosition;
    public Vector3 CameraRotation => cameraRotation;
}
