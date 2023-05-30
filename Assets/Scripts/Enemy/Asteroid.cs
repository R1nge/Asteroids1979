using UnityEngine;
using VContainer.Unity;

namespace Enemy
{
    public class Asteroid : EnemyBase
    {
        [SerializeField] private GameObject[] asteroids;

        protected override void Die()
        {
            base.Die();
            foreach (var asteroid in asteroids)
            {
                ObjectResolver.Instantiate(asteroid, transform.position, transform.rotation);
            }

            AddPoints();
            Destroy(gameObject);
        }
    }
}