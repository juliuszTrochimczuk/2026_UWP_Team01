using UnityEngine;
using System.Collections.Generic;
using Core;

public class StrongestTargetSelection : ITargetSelectionStrategy
{
    public Transform SelectTarget(IEnumerable<GameObject> enemies, Transform towerTransform, float range)
    {
        int maxHealth = -1;
        GameObject strongestEnemy = null;

        foreach (var enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(towerTransform.position, enemy.transform.position);
            if (distanceToEnemy > range) continue;

            var health = enemy.GetComponent<BaseHealth>();
            if (health != null && health.CurrentHealth > maxHealth)
            {
                maxHealth = health.CurrentHealth;
                strongestEnemy = enemy;
            }
        }

        return strongestEnemy != null ? strongestEnemy.transform : null;
    }
}
