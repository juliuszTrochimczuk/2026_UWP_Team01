using Controllers;
using UnityEngine;

namespace AI
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private int damageToBase = 10;

        public void ReachBase()
        {
            BaseHealth.Instance?.TakeDamage(damageToBase);
            WaveManager.Instance?.DecreaseWaveActiveEnemy();
            Destroy(gameObject);
        }
    }
}
