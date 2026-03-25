using UnityEngine;

namespace Wave
{
    [CreateAssetMenu(fileName = "WaveData", menuName = "Waves/Wave Data")]
    public class WaveData : ScriptableObject
    {
        [SerializeField] private GameObject enemyPrefab;
        [SerializeField] private int spawnCount = 4;

        public GameObject EnemyPrefab => enemyPrefab;

        public int SpawnCount => spawnCount;

        public bool IsPlayable => enemyPrefab != null && spawnCount > 0;
    }
}
