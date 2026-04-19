using UnityEngine;

[CreateAssetMenu(fileName = "TowerBuildConfig", menuName = "Scriptable Objects/TowerBuildConfig")]
public class TowerBuildConfig : ScriptableObject
{
    [field: SerializeField] public int TowerCost { get; set; }
    [field: SerializeField] public GameObject TowerPrefab { get; set; }
}

