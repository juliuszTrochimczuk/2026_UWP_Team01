using UnityEngine;

namespace AI
{
    [CreateAssetMenu(fileName = "Enemy_Config", menuName = "Configs/Enemy Config")]
    public class EnemyConfig : ScriptableObject
    {
        [field: SerializeField] public int Damage { get; private set; }
        [field: SerializeField] public int RewardOnDeath { get; private set; }
        [field: SerializeField] public float Speed { get; private set; }
        [field: SerializeField] public int MaxHealth { get; private set; }
    }
}