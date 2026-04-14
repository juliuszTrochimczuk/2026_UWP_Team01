using Managers;
using TMPro;
using UnityEngine;

namespace UI 
{
    public class WaveCounter : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI activeWave;
        [SerializeField] private TextMeshProUGUI maxWave;

        private void Start()
        {
            maxWave.text = WaveManager.Instance.WaveCount.ToString();
            activeWave.text = (WaveManager.Instance.CurrentWaveIndex + 1).ToString();
            WaveManager.Instance.OnWaveStartAddListener(() => 
                activeWave.text = (WaveManager.Instance.CurrentWaveIndex + 1).ToString()
            );
        }
    }
}