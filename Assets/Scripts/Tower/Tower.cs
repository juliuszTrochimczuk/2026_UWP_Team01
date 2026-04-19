using Managers;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] TowerConfig towerConfig;

    private GameObject shooter;
    private Transform firePoint;
    private Transform target;
    private float fireCountdown = 0f;

    void Start()
    {
        shooter = transform.Find("Shooter").gameObject;
        firePoint = shooter.transform.Find("FirePoint");

        SignalBus.Instance.SubscribeEvent("DefensePhaseStarted", OnDefence);
        SignalBus.Instance.SubscribeEvent("ConstructionPhaseStarted", OnConstruction);

        switch(GameManager.Instance.CurrentPhase)
        {
            case GameManager.GamePhase.Construction:
                OnConstruction();
                break;
            case GameManager.GamePhase.Defense:
                OnDefence();
                break;
        }
    }

    private void OnDefence()
    {
        if(IsInvoking(nameof(UpdateTarget)))
            return;

        InvokeRepeating(nameof(UpdateTarget), 0f, 0.1f);
    }

    private void OnConstruction()
    {
        if (!IsInvoking(nameof(UpdateTarget))) 
            return;

        CancelInvoke(nameof(UpdateTarget));
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

        if(fireCountdown <= 0f)
        {
            Shoot();
            fireCountdown = 1f / towerConfig.FireRate;
        }

        fireCountdown -= Time.deltaTime;
    }

    private void Shoot()
    {
        var bulletGO = InstanceManager.Instance.GetBullet(firePoint.position, firePoint.rotation);
        var bullet = bulletGO.GetComponent<Bullet>();
        if (bullet != null)
        {
            bullet.Seek(target);
        }
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
