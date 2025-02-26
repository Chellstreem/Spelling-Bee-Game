using UnityEngine;

public interface ICameraShaker
{
    public void ShakeCamera(Transform cameraTransform, float intensity, float duration);
    public void StopShaking();
}
