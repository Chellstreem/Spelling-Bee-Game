using UnityEngine;

namespace Camera
{
    public class MainCameraShaker : IMainCameraShaker
    {
        private readonly ICameraShaker cameraShaker;
        private readonly Transform mainCamera;

        private float intensity;
        private float duration;

        public MainCameraShaker(ICameraShaker cameraShaker, ICameraProvider cameraProvider, CameraConfig config)
        {
            this.cameraShaker = cameraShaker;
            mainCamera = cameraProvider.GetMainCamera().transform;
            intensity = config.CameraShakeIntensity;
            duration = config.CameraShakeDuration;
        }

        public void ShakeMainCamera() => cameraShaker.ShakeCamera(mainCamera, intensity, duration);       

        public void StopShaking() => cameraShaker.StopShaking();

        public void ShakeMainCamera(float intensity, float duration)
        {
            cameraShaker.ShakeCamera(mainCamera, intensity, duration);
        }
    }
}
