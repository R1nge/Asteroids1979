using UnityEngine;

namespace Weapons
{
    public class EnemyWeapon : WeaponBase
    {
        protected override void Start()
        {
            base.Start();
            InvokeRepeating(nameof(HandleFire), 0, 2f);
        }

        protected override void SpawnBullet()
        {
            var bullet = BulletSpawner.Instance.GetEnemyBullet();
            bullet.transform.position = shootPoint.position;
            if (bullet.TryGetComponent(out Rigidbody2D rb))
            {
                rb.velocity = -transform.up * bulletSpeed;
            }
        }
    }
}