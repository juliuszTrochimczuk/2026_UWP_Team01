using UnityEngine;

[CreateAssetMenu(fileName = "BulletConfig", menuName = "Scriptable Objects/BulletConfig")]
public class BulletConfig : ScriptableObject
{
    [field: SerializeField] public float Speed { get; set; }
    [field: SerializeField] public int Damage { get; set; }
    [field: SerializeField] public GameObject ImpactEffect { get; set; }
}
