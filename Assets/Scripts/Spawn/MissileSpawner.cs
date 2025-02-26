using System.Collections;
using UnityEngine;

public class MissileSpawner : Spawner, ISpawner
{
    private ISpawnableObjectProvider objectPool;
    private ICoroutineRunner coroutineRunner;
    private Vector3 spawnPosition;
    private readonly float delayBeforeLaunching;

    private Coroutine spawnCoroutine;    

    public MissileSpawner(ISpawnableObjectProvider objectPool, ICoroutineRunnerProvider runnerProvider, GameConfig gameConfig)
    {        
        this.objectPool = objectPool;
        coroutineRunner = runnerProvider.GetCoroutineRunner();
        spawnPosition = gameConfig.SpawnPosition;
        spawnFrequency = gameConfig.MissileSpawnFrequency;
        delayBeforeLaunching = gameConfig.DelayBeforeLaunching;
    }

    public override void StartSpawning()
    {
        if (spawnCoroutine == null)
        {
            spawnCoroutine = coroutineRunner.StartCor(SpawnObjects(SpawnableObjectType.Missile, spawnFrequency));
        }
    }

    public override void StopSpawning()
    {
        if (spawnCoroutine != null)
        {
            coroutineRunner.StopCor(spawnCoroutine);
            spawnCoroutine = null;
        }
    }

    protected override IEnumerator SpawnObjects(SpawnableObjectType objType, float spawnFrequency)
    {
        yield return new WaitForSeconds(delayBeforeLaunching);
        while (true)
        {
            SpawnableObject spawnObject = GetObject(objType);
            GameObject obj = spawnObject.GameObject;
            spawnObject.CachedTransform.position = GetPosition(spawnObject);
            obj.SetActive(true);
            yield return new WaitForSeconds(spawnFrequency);
        }
    }

    protected override Vector3 GetPosition(SpawnableObject spawnObject)
    {
        float z = spawnPosition.z;
        float x = spawnObject.MinPosX;
        float y = (Random.value < 0.5f ? spawnObject.MinPosY : spawnObject.MaxPosY);

        return new Vector3(x, y, z);
    }

    protected override SpawnableObject GetObject(SpawnableObjectType objType)
    {
        return objectPool.GetObject(objType);
    }    
}
