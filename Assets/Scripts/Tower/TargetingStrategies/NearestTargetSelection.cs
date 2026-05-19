using UnityEngine;
using System.Collections.Generic;

public class NearestTargetSelection : ITargetSelectionStrategy
{
    public Transform SelectTarget(IEnumerable<GameObject> enemies, Transform towerTransform, float range)
    {
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (var enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(towerTransform.position, enemy.transform.position);
            if (distanceToEnemy <= shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortestDistance <= range)
        {
            return nearestEnemy.transform;
        }

        return null;
    }
}
