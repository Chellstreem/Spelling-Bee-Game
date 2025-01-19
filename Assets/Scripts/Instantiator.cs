using UnityEngine;
using Zenject;

public class Instantiator : IPlayerHolder, ICoroutineRunnerHolder
{
    private DiContainer container;

    public ICoroutineRunner CoroutineRunner {  get; }   
    public GameObject Player { get; }
    public GameObject Background { get; }    

    public Instantiator(GameConfig gameConfig, DiContainer container)
    {
        this.container = container;

        Player = InstantiateObject(gameConfig.PlayerPrefab, gameConfig.PlayerPosition);        
        CoroutineRunner = Object.Instantiate(gameConfig.CoroutineRunnerObj).GetComponent<ICoroutineRunner>();
    }

    private GameObject InstantiateObject(GameObject prefab, Vector3 position)
    {
        GameObject obj = container.InstantiatePrefab(prefab);
        obj.transform.position = position;
        return obj;
    }
}
