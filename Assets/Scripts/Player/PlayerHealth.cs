using Core;
using UnityEngine;

namespace Player
{
    public class PlayerHealth : Health
    {
        protected override void OnCollisionEnter2D(Collision2D other)
        {
            if (!other.transform.TryGetComponent(out IDamageable damageable)) return;
            damageable.TakeDamage(1);
        }
    }
}
