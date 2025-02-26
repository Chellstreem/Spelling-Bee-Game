using System.Collections;
using UnityEngine;

namespace Camera
{
    public class CameraShaker : ICameraShaker
    {
        private readonly ICoroutineRunner coroutineRunner;

        private Coroutine coroutine;

        public CameraShaker(ICoroutineRunnerProvider runnerGetter)
        {
            coroutineRunner = runnerGetter.GetCoroutineRunner();
        }

        public void ShakeCamera(Transform cameraTransform, float intensity, float duration)
        {
            if (coroutine == null)
                coroutine = coroutineRunner.StartCor(ShakeCoroutine(cameraTransform, intensity, duration));
        }

        public void StopShaking()
        {
            if (coroutine != null)
            {
                coroutineRunner.StopCor(coroutine);
                coroutine = null;
            }
        }

        private IEnumerator ShakeCoroutine(Transform cameraTransform, float intensity, float duration)
        {
            Vector3 originalPosition = cameraTransform.localPosition;
            float elapsed = 0f;
            float shakeInterval = 0.09f; // Задержка между толчками

            while (elapsed < duration)
            {
                elapsed += Time.deltaTime;

                if (elapsed % shakeInterval < Time.deltaTime)
                {
                    float offsetX = Random.Range(-1f, 1f) * intensity;
                    float offsetY = Random.Range(-1f, 1f) * intensity;

                    cameraTransform.localPosition = originalPosition + new Vector3(offsetX, offsetY, 0f);
                }

                yield return null;
            }

            cameraTransform.localPosition = originalPosition;
        }
    }
}

