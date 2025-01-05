using UnityEngine;

[CreateAssetMenu(fileName = "SceneObjectCollection", menuName = "Scriptable Objects/SceneObjectCollection")]
public class SceneObjectCollection : ScriptableObject
{
    [SerializeField] private SceneObject[] sceneObjects;

    public SceneObject[] SceneObjects => sceneObjects;
}
