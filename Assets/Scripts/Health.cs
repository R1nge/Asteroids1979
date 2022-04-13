using System;
using UnityEngine;

public class Health : MonoBehaviour, IDamageable
{
    [SerializeField] private int health, maxHealth;
    public event Action OnDieEvent;

    private void Start() => health = maxHealth;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (!other.transform.CompareTag("Player")) return;
        if (!other.transform.TryGetComponent(out IDamageable damageable)) return;
        damageable.TakeDamage(1);
    }

    public void TakeDamage(int amount)
    {
        health -= amount;
        if (health <= 0)
        {
            OnDieEvent?.Invoke();
        }
    }
}