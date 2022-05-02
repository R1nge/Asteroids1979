using Core;
using UnityEngine;

namespace Weapons
{
    public class EnemyBullet : Bullet
    {
        protected override void OnCollision(GameObject go)
        {
            if (!go.CompareTag("Player")) return;
            if (!go.TryGetComponent(out Health health)) return;
            health.TakeDamage(damageAmount);
        }
    }
}
