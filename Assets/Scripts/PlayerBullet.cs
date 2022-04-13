using UnityEngine;

public class PlayerBullet : Bullet
{
    protected override void OnCollision(GameObject go)
    {
        if (!go.TryGetComponent(out Health health)) return;
        health.TakeDamage(damageAmount);
    }
}
