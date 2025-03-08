using System;
using System.Collections;
using UnityEngine;
using Zenject;

namespace Cameras
{
    public class CameraShaker : ICameraShaker, IInitializable, IDisposable
    {
        private readonly ICoroutineRunner coroutineRunner;
        private readonly IActiveCamera activeCamera;
        
        private Transform currentCameraTransform;        
        private Coroutine coroutine;

        public CameraShaker(ICoroutineRunner coroutineRunner, IActiveCamera activeCamera)
        {
            this.coroutineRunner = coroutineRunner;  
            this.activeCamera = activeCamera;            
        }

        public void Initialize()
        {            
            UpdateCurrentCamera();
            activeCamera.OnCameraSwitched += UpdateCurrentCamera;
        }

        public void ShakeCamera(float intensity, float duration)
        {
            if (coroutine == null)
                coroutine = coroutineRunner.StartCor(ShakeCoroutine(intensity, duration));
        }

        public void StopShaking()
        {
            if (coroutine != null)
            {
                coroutineRunner.StopCor(coroutine);
                coroutine = null;
            }
        }

        public void Dispose()
        {
            activeCamera.OnCameraSwitched -= UpdateCurrentCamera;
        }

        private void UpdateCurrentCamera()
        {
            currentCameraTransform = activeCamera.ActiveCamera.transform;            
        }

        private IEnumerator ShakeCoroutine(float intensity, float duration)
        {
            Vector3 originalPosition = currentCameraTransform.position;
            float elapsed = 0f;
            float shakeInterval = 0.09f; // Задержка между толчками

            while (elapsed < duration)
            {
                elapsed += Time.deltaTime;

                if (elapsed % shakeInterval < Time.deltaTime)
                {
                    float offsetX = UnityEngine.Random.Range(-1f, 1f) * intensity;
                    float offsetY = UnityEngine.Random.Range(-1f, 1f) * intensity;

                    currentCameraTransform.position = originalPosition + new Vector3(offsetX, offsetY, 0f);
                }

                yield return null;
            }

            currentCameraTransform.position = originalPosition;
            coroutine = null;
        }
    }
}