using Cameras;
using System;
using UnityEngine;

namespace Cameras
{
    public class CameraSwitcher : ICameraSwitcher, IActiveCamera
    {
        private readonly ICameraGetter cameraGetter;
        private GameObject activeCamera;

        public GameObject ActiveCamera => activeCamera;
        public event Action OnCameraSwitched;

        public CameraSwitcher(ICameraGetter cameraGetter)
        {
            this.cameraGetter = cameraGetter;
        }

        public void SwitchCamera(CameraType cameraType)
        {
            GameObject newCamera = cameraGetter.GetCamera(cameraType);

            if (activeCamera == newCamera) return;
            DeactivateActiveCamera();

            newCamera.SetActive(true);
            activeCamera = newCamera;
            OnCameraSwitched?.Invoke();            
        }        

        private void DeactivateActiveCamera()
        {
            if (activeCamera != null)
            {
                activeCamera.SetActive(false);
            }
        }
    }
}
