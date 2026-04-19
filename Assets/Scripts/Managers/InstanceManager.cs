using Abstraction;
using Core;
using UnityEngine;

namespace Managers
{
    public class InstanceManager : PersistentSingleton<InstanceManager>
    {
        [SerializeField] private TowerBuildConfig towerBuildConfig;
        [SerializeField] private GameObject bulletPrefab;

        protected override InstanceManager CreateInstance() => this;

        public GameObject GetTower(Vector3 position, Quaternion rotation)
        {
            if (CoinsManager.Instance.TryRemoveCoins(towerBuildConfig.TowerCost))
            {
                return UniversalFactory.Instance.Create(new(towerBuildConfig.TowerPrefab, position, rotation));
            }
            else
            {
                return null;
            }
        }

        public GameObject GetBullet(Vector3 position, Quaternion rotation)
        {
            return UniversalFactory.Instance.Create(new(bulletPrefab, position, rotation));
        }
    }
}
