using UnityEngine;

[CreateAssetMenu(fileName = "SceneObjectCollection", menuName = "Scriptable Objects/SceneObjectCollection")]
public class SceneObjectCollection : ScriptableObject
{
    [SerializeField] private SceneObjectConfig[] sceneObjects;

    public SceneObjectConfig[] SceneObjects => sceneObjects;
}
