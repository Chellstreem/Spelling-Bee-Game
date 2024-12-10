using UnityEngine;


[CreateAssetMenu(fileName = "SpawnableConfig", menuName = "Scriptable Objects/SpawnableConfig")]
public class SpawnableConfig : ScriptableObject
{
    public enum ObjectGroup
    {
        DecorAnimals, 
        DecorPlants, 
        Interactable
    }

    private const int MaxCopies = 12;
    
    public ObjectGroup objectGroup;
    public GameObject prefab;     
    public float minPosX;
    public float maxPosX;
    public float minPosY;
    public float maxPosY;

    [Range(0, MaxCopies)]
    public int priorityWeight; // Количество объектов в пуле. Определяет вероятность появления
}
