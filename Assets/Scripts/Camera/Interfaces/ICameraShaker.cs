using UnityEngine;

public interface ICameraShaker
{
    public void ShakeCamera(float intensity, float duration);
    public void StopShaking();
}
