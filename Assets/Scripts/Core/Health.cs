using System;
using UnityEngine;

namespace Core
{
    public abstract class Health : MonoBehaviour, IDamageable
    {
        [SerializeField] private int health, maxHealth;
        public event Action OnDieEvent;

        private void Start() => health = maxHealth;

        protected abstract void OnCollisionEnter2D(Collision2D other);

        public void TakeDamage(int amount)
        {
            health -= amount;
            if (health <= 0)
            {
                OnDieEvent?.Invoke();
            }
        }
    }
}
