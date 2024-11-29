using UnityEngine;

namespace Version_1
{
    public class LaserWeapon : Weapon
    {
        [SerializeField] private Transform firingPoint;
        [SerializeField] private float damage;
        protected override void Fire()
        {
            Debug.DrawRay(firingPoint.position, firingPoint.forward * 100, Color.yellow, 0.5f);
            if (Physics.Raycast(firingPoint.position, firingPoint.forward, out RaycastHit hit, 100))
            {
                Rigidbody rb = hit.rigidbody;
                if (!rb || !rb.TryGetComponent(out IDamagable target)) return;
                target.TakeDamage(damage);
            }
        }
    }
}
