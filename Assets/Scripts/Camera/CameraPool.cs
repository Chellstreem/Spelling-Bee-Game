using System.Collections.Generic;
using UnityEngine;

namespace Cameras
{
    public class CameraPool : ICameraGetter
    {
        private readonly CameraObject[] cameraObjects;

        private Dictionary<CameraType, GameObject> cameraMap;
        private GameObject poolHolder;

        public CameraPool(CameraConfig cameraConfig)
        {
            cameraObjects = cameraConfig.CameraObjects; 
            
            InitializePool();
        }

        public GameObject GetCamera(CameraType cameraType)
        {
            if (cameraMap.TryGetValue(cameraType, out GameObject camera))
            {
                return camera;
            }
            else
            {
                Debug.LogWarning($"Камера типа {cameraType} не найдена в пуле!");
                return null;
            }
        }

        private void InitializePool()
        {
            cameraMap = new Dictionary<CameraType, GameObject>();
            poolHolder = new GameObject("Camera Pool");

            foreach (var cameraObject in cameraObjects)
            {
                if (!cameraMap.ContainsKey(cameraObject.CameraType))
                {
                    GameObject instantiatedCamera = Object.Instantiate(cameraObject.CameraPrefab, poolHolder.transform);
                    instantiatedCamera.SetActive(false);
                    cameraMap.Add(cameraObject.CameraType, instantiatedCamera);
                }
            }
        }
    }
}
