using System;
using Core;
using UnityEngine;
using VContainer;

namespace Enemy
{
    public abstract class EnemyBase : MonoBehaviour
    {
        [SerializeField] private int points;
        [SerializeField] private int amountOfChildren;
        private Health _health;
        private ScoreHandler _scoreHandler;
        protected IObjectResolver ObjectResolver;

        public static event Action<int> OnEnemyDied;

        [Inject]
        private void Construct(IObjectResolver objectResolver, ScoreHandler scoreHandler)
        {
            ObjectResolver = objectResolver;
            _scoreHandler = scoreHandler;
        }

        protected virtual void Awake()
        {
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