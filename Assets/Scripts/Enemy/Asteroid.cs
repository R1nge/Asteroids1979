using UnityEngine;

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
                Instantiate(asteroid, transform.position, transform.rotation);
            }

            AddPoints();
            Destroy(gameObject);
        }
    }
}