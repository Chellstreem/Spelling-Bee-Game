using UnityEngine;

[CreateAssetMenu(fileName = "SpawnableConfig", menuName = "Scriptable Objects/SpawnableConfig")]
public class SpawnableObjectConfig : ScriptableObject
{
    [SerializeField] private SpawnableObjectType objType;
    [SerializeField] private GameObject prefab;
    [SerializeField] private float minPosX;
    [SerializeField] private float maxPosX;
    [SerializeField] private float minPosY;
    [SerializeField] private float maxPosY;

    [Range(0, MaxCopies)]
    [SerializeField] private int priorityWeight; // Количество объектов в пуле. Определяет вероятность появления объекта
    private const int MaxCopies = 20;

    public SpawnableObjectType ObjType => objType;
    public GameObject Prefab => prefab;
    public float MinPosX => minPosX;
    public float MaxPosX => maxPosX;
    public float MinPosY => minPosY;
    public float MaxPosY => maxPosY;
    public int PriorityWeight => priorityWeight;
}
