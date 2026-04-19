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
            CurrentPhase = GamePhase.Construction;
            SignalBus.Instance?.FireSignal("ConstructionPhaseStarted");
            timeRemaining = constructionDuration;

            StartCoroutine(ConstructionCountdown());
        }

        public void StartDefensePhase()
        {
            CurrentPhase = GamePhase.Defense;
            SignalBus.Instance?.FireSignal("DefensePhaseStarted");
            WaveManager.Instance?.BeginDefenseWaves();
        }

        public void OnWin()
        {
            SignalBus.Instance?.FireSignal("GameWon");
        }

        public void OnLose()
        {
            WaveManager.Instance?.AbortWaves();
            SignalBus.Instance?.FireSignal("GameLost");
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
