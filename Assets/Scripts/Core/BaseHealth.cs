using UnityEngine;

namespace Controllers
{
    public class BaseHealth : Singleton<BaseHealth>
    {
        [SerializeField] private int maxHealth = 100;

        private int currentHealth;

        protected override void CreateInstance() => Instance = this;

        protected override void OnAwake()
        {
            currentHealth = maxHealth;
        }

        public void TakeDamage(int amount)
        {
            if (amount <= 0)
                return;

            currentHealth -= amount;
            if (currentHealth <= 0)
                GameManager.Instance?.OnLose();
        }
    }
}
