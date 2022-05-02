using System;
using Core;
using UnityEngine;

namespace Enemy
{
    public abstract class EnemyBase : MonoBehaviour
    {
        [SerializeField] private int points;
        [SerializeField] private int amountOfChildren;
        private ScoreHandler _scoreHandler;
        private Health _health;

        public static event Action<int> OnEnemyDied;

        protected virtual void Awake()
        {
            _scoreHandler = FindObjectOfType<ScoreHandler>();
            _health = GetComponent<Health>();
            _health.OnDieEvent += Die;
        }

        protected virtual void Die()
        {
            Destroy(gameObject);
            AddPoints();
            OnEnemyDied?.Invoke(amountOfChildren);
        }

        protected void AddPoints() => _scoreHandler.AddScore(points);

        private void OnDestroy() => _health.OnDieEvent -= Die;
    }
}