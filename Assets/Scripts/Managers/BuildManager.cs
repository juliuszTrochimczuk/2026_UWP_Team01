using Abstraction;
using UnityEngine;

namespace Managers
{
    public class BuildManager : PersistentSingleton<BuildManager>
    {
        [SerializeField] private GameObject towerPrefab;

        protected override BuildManager CreateInstance() => this;

        public GameObject GetTower(Vector3 position, Quaternion rotation)
        {
            return TowerFactory.Instance.Create(new(towerPrefab, position, rotation));
        }
    }
}
