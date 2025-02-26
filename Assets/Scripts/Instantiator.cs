using UnityEngine;
using Zenject;

public class Instantiator : IPlayerGetter, ICoroutineRunnerProvider, ICameraProvider
{
    private DiContainer container;    

    public ICoroutineRunner CoroutineRunner { get; private set; }   
    public GameObject Player { get; private set;  }
    public UnityEngine.Camera MainCamera { get; private set; }

    public Instantiator(DiContainer container, GameConfig gameConfig, CameraConfig cameraConfig)
    {
        this.container = container;

        Player = CreateObject(gameConfig.PlayerPrefab, gameConfig.LowerPlayerPosition, Quaternion.identity);
        CoroutineRunner = container.InstantiatePrefabForComponent<ICoroutineRunner>(gameConfig.CoroutineRunnerPrefab);
        MainCamera = container.InstantiatePrefabForComponent<UnityEngine.Camera>(cameraConfig.CameraPrefab);
    }    

    public GameObject GetPlayer() => Player;

    public ICoroutineRunner GetCoroutineRunner() => CoroutineRunner;
    
    public UnityEngine.Camera GetMainCamera() => MainCamera;  

    private GameObject CreateObject(GameObject prefab, Vector3 position, Quaternion rotation)
    {
        GameObject obj = container.InstantiatePrefab(prefab);
        obj.transform.position = position;
        obj.transform.rotation = rotation;
        return obj;
    }    
} 

