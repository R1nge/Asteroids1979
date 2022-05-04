using Core;
using UnityEngine;

namespace Enemy
{
    public class EnemyHealth : Health
    {
        protected override void OnCollisionEnter2D(Collision2D other);
        {
            if (!other.transform.CompareTag("Player")) return;
            if (!other.transform.TryGetComponent(out IDamageable damageable)) return;
            damageable.TakeDamage(1);
        }
    }
}
