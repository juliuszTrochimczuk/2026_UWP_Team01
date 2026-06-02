using Managers;
using TMPro;
using UnityEngine;

namespace UI 
{
    public class GameResultScreen : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI winText;
        [SerializeField] private TextMeshProUGUI loseText;

        private void Awake()
        {
            winText.gameObject.SetActive(false);
            loseText.gameObject.SetActive(false);
        }

        private void Start()
        {
            SignalBus.Instance.SubscribeEvent("GameWon", ShowWonGameText);
            SignalBus.Instance.SubscribeEvent("GameLost", ShowLostGameText);
            gameObject.SetActive(false);
        }

        private void ShowWonGameText()
        {
            gameObject.SetActive(true);
            winText.gameObject.SetActive(true);
        }

        private void ShowLostGameText()
        {
            gameObject.SetActive(true);
            loseText.gameObject.SetActive(true);
        }
    }
}