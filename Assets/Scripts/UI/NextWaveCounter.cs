using Managers;
using TMPro;
using UnityEngine;

namespace UI
{
    public class NextWaveCounter : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI enemyType;
        [SerializeField] private TextMeshProUGUI enemyCount;

        public void UpdateNextWaveCounter(string enemyType, string enemyCount)
        {
            this.enemyType.text = enemyType;
            this.enemyCount.text = enemyCount;
        }
    }
}

