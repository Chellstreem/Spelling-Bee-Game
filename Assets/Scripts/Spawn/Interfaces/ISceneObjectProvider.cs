using UnityEngine;

public interface ISceneObjectProvider
{
    public GameObject[] GetObjects(SceneObjectType objectType);
}
