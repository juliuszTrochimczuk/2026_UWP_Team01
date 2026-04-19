using Abstraction;
using UnityEngine;

namespace Core
{
    public class UniversalFactory : Factory<UniversalFactory, GameObject, CreateGameObjectParams>
    {
        public override GameObject Create(CreateGameObjectParams param)
        {
            var towerInstance = Instantiate(param.Prefab, param.SpawnPos, param.SpawnRotation);
            return towerInstance;
        }

        protected override UniversalFactory CreateInstance() => this;
    }
}
