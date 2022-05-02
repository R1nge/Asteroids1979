using Core;
using UnityEngine;

namespace Weapons
{
    public class PlayerBullet : Bullet
    {
        protected override void OnCollision(GameObject go)
        {
            if (!go.TryGetComponent(out Health health)) return;
            health.TakeDamage(damageAmount);
        }
    }
}
