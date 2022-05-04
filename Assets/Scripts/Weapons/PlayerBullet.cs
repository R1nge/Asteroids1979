using Core;
using UnityEngine;

namespace Weapons
{
    public class PlayerBullet : Bullet
    {
        public override void OnTriggerEnter2D(Collider2D other)
        {
            base.OnTriggerEnter2D(other);
            if (!other.TryGetComponent(out IDamageable damageable)) return;
            damageable.TakeDamage(damageAmount);
        }
    }
}