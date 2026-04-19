using UnityEngine;

[CreateAssetMenu(fileName = "TowerConfig", menuName = "Scriptable Objects/TowerConfig")]
public class TowerConfig : ScriptableObject
{
    [field: SerializeField] public float TowerRange { get; set; }
    [field: SerializeField] public float FireRate { get; set; }
    [field: SerializeField] public float TurnSpeed { get; set; }
    [field: SerializeField] public string EnemyTag { get; set; }
}
