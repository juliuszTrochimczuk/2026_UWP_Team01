using Abstraction;
using UnityEngine;

public class TowerFactory : Factory<TowerFactory, GameObject, TowerCreateParams>
{
    public override GameObject Create(TowerCreateParams param)
    {
        var towerInstance = Instantiate(param.TowerPrefab, param.SpawnPos, param.SpawnRotation);
        return towerInstance;
    }

    protected override TowerFactory CreateInstance() => this;
}

