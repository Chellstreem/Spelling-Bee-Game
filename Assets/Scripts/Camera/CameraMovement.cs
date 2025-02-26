using Camera;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Camera
{
    public class CameraMovement : ICameraMover
    {
        private ICoroutineRunner coroutineRunner;
        private Dictionary<CameraStateType, CameraState> stateMap;

        private Coroutine coroutine;

        public CameraMovement(ICoroutineRunnerProvider runnerProvider, CameraConfig config)
        {
            coroutineRunner = runnerProvider.GetCoroutineRunner();

            InitializeStateMap(config);
        }

        public void ChangeStateSmoothly(Transform cameraTransform, CameraStateType stateType, float duration)
        {
            if (coroutine != null)
                coroutineRunner.StopCor(coroutine);

            coroutine = coroutineRunner.StartCor(MoveAndRotateCoroutine(cameraTransform, stateType, duration));
        }

        public void ChangeState(Transform cameraTransform, CameraStateType stateType)
        {
            CameraState targetState = stateMap[stateType];
            cameraTransform.position = targetState.CameraPosition;
            cameraTransform.rotation = Quaternion.Euler(targetState.CameraRotation);
        }

        private void InitializeStateMap(CameraConfig cameraConfig)
        {
            stateMap = new Dictionary<CameraStateType, CameraState>();
            foreach (CameraState gameState in cameraConfig.States)
            {
                if (!stateMap.ContainsKey(gameState.CamState))
                {
                    stateMap[gameState.CamState] = gameState;
                }
            }
        }

        private IEnumerator MoveAndRotateCoroutine(Transform cameraTransform, CameraStateType stateType, float duration)
        {
            Vector3 originalPosition = cameraTransform.position;
            Quaternion originalRotation = cameraTransform.rotation;

            CameraState targetState = stateMap[stateType];
            Vector3 targetPosition = targetState.CameraPosition;
            Quaternion targetRotation = Quaternion.Euler(targetState.CameraRotation);

            float elapsedTime = 0f;
            while (elapsedTime < duration)
            {
                float t = Mathf.SmoothStep(0f, 1f, elapsedTime / duration);
                cameraTransform.position = Vector3.Lerp(originalPosition, targetPosition, t);
                cameraTransform.rotation = Quaternion.Slerp(originalRotation, targetRotation, t);
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            cameraTransform.position = targetPosition;
            cameraTransform.rotation = targetRotation;
        }
    }
}

