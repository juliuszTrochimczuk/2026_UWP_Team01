using UnityEngine;

namespace Wave
{
    [CreateAssetMenu(fileName = "WaveData", menuName = "Waves/Wave Data")]
    public class WaveData : ScriptableObject
    {
        [SerializeField] private GameObject enemyPrefab;
        [SerializeField] private int spawnCount = 4;
        [SerializeField] private string enemyType;

        public GameObject EnemyPrefab => enemyPrefab;

        public int SpawnCount => spawnCount;
        public string EnemyType => enemyType;

        public bool IsPlayable => enemyPrefab != null && spawnCount > 0;
    }
}
