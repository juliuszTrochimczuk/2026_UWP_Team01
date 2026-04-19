using Managers;
using TMPro;
using UnityEngine;

namespace UI
{
    public class CoinsCounter : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI coinsCounter;

        public void UpdateCoinsCounter(string coinsCounter)
        {
            this.coinsCounter.text = coinsCounter;
        }
    }
}
