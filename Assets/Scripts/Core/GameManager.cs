using UnityEngine;

namespace Controllers
{
    public class GameManager : PersistentSingleton<GameManager>
    {
        protected override void CreateInstance() => Instance = this;

        public enum GamePhase
        {
            Construction,
            Defense
        }

        public GamePhase CurrentPhase { get; private set; }

        protected override void OnAwake()
        {
            base.OnAwake();
            //for demonstration purposes
            StartDefensePhase();
        }

        public void StartConstructionPhase()
        {
            CurrentPhase = GamePhase.Construction;
            SignalBus.Instance?.FireSignal("ConstructionPhaseStarted");
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
    }
}
