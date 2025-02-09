using UnityEngine;

public class MissileSpawner : Spawner, ISpawner
{
    private ISpawnableObjectProvider objectPool;
    private ICoroutineRunner coroutineRunner;
    private Vector3 spawnPosition;    
    
    private Coroutine spawnCoroutine;
    private bool isMinPosY = false; // Флаг для отслеживания, какое значение Y использовать

    public MissileSpawner(ISpawnableObjectProvider objectPool, ICoroutineRunnerHolder runnerHolder, GameConfig gameConfig)
    {        
        this.objectPool = objectPool;
        coroutineRunner = runnerHolder.CoroutineRunner;
        spawnPosition = gameConfig.SpawnPosition;
        spawnFrequency = gameConfig.MissileSpawnFrequency;
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

    protected override Vector3 GetPosition(SpawnableObject spawnObject)
    {
        float z = spawnPosition.z;
        float x = Random.Range(spawnObject.MinPosX, spawnObject.MaxPosX);
        float y = GetNextYPosition(spawnObject);

        return new Vector3(x, y, z);
    }

    protected override SpawnableObject GetObject(SpawnableObjectType objType)
    {
        return objectPool.GetObject(objType);
    }

    private float GetNextYPosition(SpawnableObject spawnObject)
    {
        if (!isMinPosY && Random.value < 0.5f)
        {
            isMinPosY = true;
        }
        float y = isMinPosY ? spawnObject.MinPosY : spawnObject.MaxPosY;        
        isMinPosY = !isMinPosY;

        return y;
    }
}
