using Managers;
using Towers;
using UnityEngine;

namespace AI
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private int damageToBase = 10;

        public void ReachBase()
        {
            MainBase.Instance.BaseHealth.CurrentHealth -= damageToBase;
            WaveManager.Instance?.DecreaseWaveActiveEnemy();
            Destroy(gameObject);
        }
    }
}
