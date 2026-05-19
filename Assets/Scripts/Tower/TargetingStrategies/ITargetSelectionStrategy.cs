using UnityEngine;
using System.Collections.Generic;

public interface ITargetSelectionStrategy
{
    Transform SelectTarget(IEnumerable<GameObject> enemies, Transform towerTransform, float range);
}
