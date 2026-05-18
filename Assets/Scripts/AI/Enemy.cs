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

        private void Start() => presenter = new HealthPresenter(healthComponent, healthView);

        private void OnDestroy() => presenter.Disconnect();

        public void ReachBase()
        {
            MainBase.Instance.BaseHealth.CurrentHealth -= damageToBase;
            DisableEnemy();
        }

        public void Die()
        {
            CoinsManager.Instance?.AddCoins(rewardOnDeath);
            DisableEnemy();
        }

        private void DisableEnemy()
        {
            WaveManager.Instance?.DecreaseWaveActiveEnemy();
            EnemyPool.Instance.ReturnToPool(this);
        }
    }
}
