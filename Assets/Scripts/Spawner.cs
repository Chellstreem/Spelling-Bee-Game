using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private ObjectPool pool;
    private const float PlantSpawnFrequency = 1.2f;
    private const float AnimalSpawnFrequency = 1.5f;
    private const float InteractableSpawnFrequency = 0.5f;

    private List<Coroutine> activeDecorCoroutines = new List<Coroutine>();
    private List<Coroutine> activeInteractableCoroutines = new List<Coroutine>();

    public void Initialize(ObjectPool objectPool)
    {
        pool = objectPool; 
        SubscribeToEvents();
    }

    private IEnumerator SpawnObjects(SpawnableConfig.ObjectGroup objectGroup, float spawnFrequency)
    {
        while (true)
        {
            SpawnObject spawnObject = pool.GetRandomObject(objectGroup);
            GameObject gameObj = spawnObject.gameObject;
            spawnObject.cachedTransform.position = GetRandomPosition(spawnObject);
            gameObj.SetActive(true);
            yield return new WaitForSeconds(spawnFrequency);
        }
    }

    private void StartDecorCoroutines()
    {
        activeDecorCoroutines.Add(StartCoroutine(SpawnObjects(SpawnableConfig.ObjectGroup.DecorPlants, PlantSpawnFrequency)));
        activeDecorCoroutines.Add(StartCoroutine(SpawnObjects(SpawnableConfig.ObjectGroup.DecorAnimals, AnimalSpawnFrequency)));
    }

    private void StartInteractableCoroutines() => activeInteractableCoroutines.Add(StartCoroutine(SpawnObjects(SpawnableConfig.ObjectGroup.Interactable, InteractableSpawnFrequency)));

    private void StopDecorCoroutines()
    {
        foreach (Coroutine coroutine in activeDecorCoroutines)
        {
            if (coroutine != null)
                StopCoroutine(coroutine);
        }
        activeDecorCoroutines.Clear();
    }

    private void StopInteractableCoroutines()
    {
        foreach (Coroutine coroutine in activeInteractableCoroutines)
        {
            if (coroutine != null)
                StopCoroutine(coroutine);
        }
        activeInteractableCoroutines.Clear();
    }

    private Vector3 GetRandomPosition(SpawnObject spawnObject)
    {
        float z = transform.position.z;

        if (spawnObject.objectGroup != SpawnableConfig.ObjectGroup.Interactable)
        {
            float x = Random.Range(spawnObject.minPosX, spawnObject.maxPosX);
            float y = Random.Range(spawnObject.minPosY, spawnObject.maxPosY);
            return new Vector3(x, y, z);
        }
        else
        {
            float x = Random.Range(spawnObject.minPosX, spawnObject.maxPosX);
            float y = (Random.value < 0.5f ? spawnObject.minPosY : spawnObject.maxPosY);
            return new Vector3(x, y, z);
        }
    }

    private void SubscribeToEvents()
    {
        MovingState.OnMovingStarted += StartDecorCoroutines;
        MovingState.OnMovingStopped += StopDecorCoroutines;
        MovingState.UnsafeSubstate.OnUnsafeSubstateEnter += StartInteractableCoroutines;
        MovingState.UnsafeSubstate.OnUnsafeSubstateExit += StopInteractableCoroutines;
    }

    private void UnsubscribeFromEvents()
    {
        MovingState.OnMovingStarted -= StartDecorCoroutines;
        MovingState.OnMovingStopped -= StopDecorCoroutines;
        MovingState.UnsafeSubstate.OnUnsafeSubstateEnter -= StartInteractableCoroutines;
        MovingState.UnsafeSubstate.OnUnsafeSubstateExit -= StopInteractableCoroutines;
    }

    private void OnDestroy()
    {
        UnsubscribeFromEvents();
    }
}