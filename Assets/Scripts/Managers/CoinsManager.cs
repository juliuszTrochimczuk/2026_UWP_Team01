using Abstraction;
using Presenters;
using UI;
using UnityEngine;
using UnityEngine.Events;

namespace Managers
{
    public class CoinsManager : Singleton<CoinsManager>
    {
        [field: SerializeField] public int Coins { get; private set; }
        [SerializeField] private CoinsCounter coinsCounter;
        private CoinsPresenter coinsCounterPresenter;

        protected override CoinsManager CreateInstance() => this;

        [SerializeField] private UnityEvent onCoinsChanged;
        public void OnCoinsChangedAddListener(UnityAction action) => onCoinsChanged.AddListener(action);
        public void OnCoinsChangedRemoveListener(UnityAction action) => onCoinsChanged.RemoveListener(action);

        private void Start()
        {
            coinsCounterPresenter = new CoinsPresenter(coinsCounter);
        }

        public void AddCoins(int amount)
        {
            Coins += amount;
            onCoinsChanged.Invoke();
        }

        public bool TryRemoveCoins(int amount) 
        {
            if (Coins - amount >= 0)
            {
                Coins -= amount;
                onCoinsChanged.Invoke();
                return true;
            }
            return false;
        }

        private void OnDestroy()
        {
            coinsCounterPresenter.Disconnect();
        }
    }
}
