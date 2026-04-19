using Core;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private BulletConfig config;

    private Transform target;

    public void Seek(Transform _target)
    {
        target = _target;
    }

    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        var dir = target.position - transform.position;
        var distanceThisFrame = config.Speed * Time.deltaTime;

        if (dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
        transform.LookAt(target);
    }

    private void HitTarget()
    {
        var effect = UniversalFactory.Instance.Create(new(config.ImpactEffect, transform.position, transform.rotation));

        var enemyHeatlh = target.GetComponent<BaseHealth>();
        enemyHeatlh.CurrentHealth -= config.Damage;

        Destroy(effect, 2f);
        Destroy(gameObject);
    }
}
