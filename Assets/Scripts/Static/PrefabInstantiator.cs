using UnityEngine;

public static class PrefabInstantiator
{
    public static GameObject Instantiate(GameObject prefab)
    {
        return Object.Instantiate(prefab);
    }

    public static GameObject Instantiate(GameObject prefab, Vector3 position, Quaternion rotation)
    {
        return Object.Instantiate(prefab, position, rotation);
    }

    public static GameObject Instantiate(GameObject prefab, Transform parent, Vector3 localPosition, Quaternion localRotation)
    {
        GameObject instance = Object.Instantiate(prefab, parent);
        instance.transform.localPosition = localPosition;
        instance.transform.localRotation = localRotation;
        return instance;
    }
}
