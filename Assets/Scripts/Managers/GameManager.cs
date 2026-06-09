using Abstraction;
using System.Collections;
using TMPro;
using UnityEngine;

namespace Managers
{
    public class GameManager : PersistentSingleton<GameManager>
    {
        [SerializeField] private float constructionDuration = 30f;
        [SerializeField] private TextMeshProUGUI timerText; // I'm tired of creation separate manager for each UI element
        private float timeRemaining;

        protected override GameManager CreateInstance() => this;

        public enum GamePhase
        {
            Construction,
            Defense
        }

        public GamePhase CurrentPhase { get; private set; }

        protected override void Awake()
        {
            base.Awake();

            StartConstructionPhase();
        }

        public void StartConstructionPhase()
        {
            AudioManager.Instance?.Stop("DefenseTheme");
            AudioManager.Instance?.Play("ConstructionTheme");

            CurrentPhase = GamePhase.Construction;
            SignalBus.Instance?.FireSignal("ConstructionPhaseStarted");
            timeRemaining = constructionDuration;

            StartCoroutine(ConstructionCountdown());
        }

        public void StartDefensePhase()
        {
            AudioManager.Instance?.Stop("ConstructionTheme");
            AudioManager.Instance?.Play("DefenseTheme");

            CurrentPhase = GamePhase.Defense;
            SignalBus.Instance?.FireSignal("DefensePhaseStarted");
            WaveManager.Instance?.BeginDefenseWaves();
        }

        public void OnWin() {
            AudioManager.Instance?.Stop("ConstructionTheme");
            AudioManager.Instance?.Stop("DefenseTheme");

            SignalBus.Instance?.FireSignal("GameWon");
            AudioManager.Instance?.Play("Victory");
        }

        public void OnLose()
        {
            AudioManager.Instance?.Stop("ConstructionTheme");
            AudioManager.Instance?.Stop("DefenseTheme");

            WaveManager.Instance?.AbortWaves();
            SignalBus.Instance?.FireSignal("GameLost");
            var rand = Random.Range(0, 1);
            if (rand == 0)
            {
                AudioManager.Instance?.Play("Fahh");
            }
            else
            {
                AudioManager.Instance?.Play("Vine-boom");
            }
        }

        IEnumerator ConstructionCountdown()
        {
            while (timeRemaining > 0)
            {
                timerText.text = "Build Time: " + Mathf.CeilToInt(timeRemaining).ToString();

                timeRemaining -= Time.deltaTime;

                yield return null;
            }
            timerText.enabled = false;

            StartDefensePhase();
        }
    }
}
