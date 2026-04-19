using Core;
using Managers;
using Presenters;
using Towers;
using UI;
using UnityEngine;

namespace AI
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private BaseHealth healthComponent;
        [SerializeField] private HealthBar healthView;

        [SerializeField] private int damageToBase = 10;
        [SerializeField] private int rewardOnDeath = 5;

        private HealthPresenter presenter;

        void Start()
        {
            presenter = new HealthPresenter(healthComponent, healthView);
        }

        public void ReachBase()
        {
            MainBase.Instance.BaseHealth.CurrentHealth -= damageToBase;
            WaveManager.Instance?.DecreaseWaveActiveEnemy();
            Destroy(gameObject);
        }

        public void Die()
        {
            CoinsManager.Instance?.AddCoins(rewardOnDeath);
            WaveManager.Instance?.DecreaseWaveActiveEnemy();
            Destroy(gameObject);
        }

        void OnDestroy()
        {
            presenter.Disconnect();
        }
    }
}
