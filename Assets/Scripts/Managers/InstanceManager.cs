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

        public GameObject GetTower(Vector3 position, Quaternion rotation) =>
            CoinsManager.Instance.TryRemoveCoins(towerBuildConfig.TowerCost) ?
                UniversalFactory.Instance.Create(new(towerBuildConfig.TowerPrefab, position, rotation)) : null;
    }
}
