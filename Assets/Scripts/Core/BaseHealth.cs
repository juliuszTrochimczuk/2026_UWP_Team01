using UnityEngine;
using UnityEngine.Events;

namespace Controllers
{
    public class BaseHealth : MonoBehaviour
    {
        [field: SerializeField] public int MaxHealth { get; private set; } = 100;

        [SerializeField] private UnityEvent<BaseHealth> onHealthChange;
        public void OnHealthChangeAddListener(UnityAction<BaseHealth> action) => onHealthChange.AddListener(action);
        public void OnHealthChangeRemoveListener(UnityAction<BaseHealth> action) => onHealthChange.RemoveListener(action);

        [SerializeField] private UnityEvent<BaseHealth> onTakeDamage;
        public void OnTakeDamageAddListener(UnityAction<BaseHealth> action) => onTakeDamage.AddListener(action);
        public void OnTakeDamageRemoveListener(UnityAction<BaseHealth> action) => onTakeDamage.RemoveListener(action);

        [SerializeField] private UnityEvent<BaseHealth> onHealing;
        public void OnHealingAddListener(UnityAction<BaseHealth> action) => onHealing.AddListener(action);
        public void OnHealingRemoveListener(UnityAction<BaseHealth> action) => onHealing.RemoveListener(action);

        [SerializeField] private UnityEvent<BaseHealth> onDie;
        public void OnDieAddListener(UnityAction<BaseHealth> action) => onDie.AddListener(action);
        public void OnDieRemoveListener(UnityAction<BaseHealth> action) => onDie.RemoveListener(action);

        private int currentHealth;
        public int CurrentHealth
        {
            get => currentHealth;
            set
            {
                if (value > MaxHealth)
                    CurrentHealth = MaxHealth;
                else if (value <= 0)
                {
                    if (currentHealth > 0)
                        onDie.Invoke(this);
                }
                else
                {
                    if (value < currentHealth)
                        onTakeDamage.Invoke(this);
                    else if (value > currentHealth)
                        onHealing.Invoke(this);
                }
                currentHealth = value;
                onHealthChange.Invoke(this);
            }
        }

        private void Awake() => currentHealth = MaxHealth;
    }
}
