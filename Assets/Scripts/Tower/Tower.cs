using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] TowerConfig towerConfig;
    GameObject shooter;

    private Transform target;

    void Start()
    {
        shooter = transform.Find("Shooter").gameObject;
        InvokeRepeating(nameof(UpdateTarget), 0f, 0.1f);
    }

    void UpdateTarget()
    {
        var enemies = GameObject.FindGameObjectsWithTag(towerConfig.EnemyTag);
        var shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (var enemy in enemies)
        {
            var  distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy <= shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortestDistance <= towerConfig.TowerRange)
        {
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }
    }

    void Update()
    {
        if (target == null)
        {
            return;
        }

        var dir = target.position - transform.position;
        dir.y = 0f;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        shooter.transform.rotation = Quaternion.Slerp(shooter.transform.rotation, lookRotation, Time.deltaTime * towerConfig.TurnSpeed);
    }

    private void OnDrawGizmos()
    {
        if (towerConfig != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, towerConfig.TowerRange);
        }
    }
}
