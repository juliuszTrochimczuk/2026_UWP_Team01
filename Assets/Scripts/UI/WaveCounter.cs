using TMPro;
using UnityEngine;

namespace UI 
{
    public class WaveCounter : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI activeWave;
        [SerializeField] private TextMeshProUGUI maxWave;

        public void UpdateWaveCounter(string activeWave, string maxWave)
        {
            this.activeWave.text = activeWave;
            this.maxWave.text = maxWave;
        }
    }
}