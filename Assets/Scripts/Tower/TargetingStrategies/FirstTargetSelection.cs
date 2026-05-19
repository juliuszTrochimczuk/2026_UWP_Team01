using UnityEngine;
using System.Collections.Generic;
using AI;

public class FirstTargetSelection : ITargetSelectionStrategy
{
    public Transform SelectTarget(IEnumerable<GameObject> enemies, Transform towerTransform, float range)
    {
        float maxProgress = -1f;
        GameObject firstEnemy = null;

        foreach (var enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(towerTransform.position, enemy.transform.position);
            if (distanceToEnemy > range) continue;

            var movement = enemy.GetComponent<EnemyMovement>();
            if (movement != null && movement.Progress > maxProgress)
            {
                maxProgress = movement.Progress;
                firstEnemy = enemy;
            }
        }

        return firstEnemy != null ? firstEnemy.transform : null;
    }
}
