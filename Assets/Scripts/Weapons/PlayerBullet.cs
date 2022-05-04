using Core;
using UnityEngine;

namespace Weapons
{
    public class PlayerBullet : Bullet
    {
        protected override void OnCollision(GameObject go)
        {
            if (!go.TryGetComponent(out IDamageable damageable)) return;
            damageable.TakeDamage(damageAmount);
        }
    }
}
