using UnityEngine;
using VContainer;

namespace Weapons
{
    public abstract class WeaponBase : MonoBehaviour
    {
        [SerializeField] protected float bulletSpeed;
        [SerializeField] private float reloadTime;
        [SerializeField] protected Transform shootPoint;
        [SerializeField] private int ammoAmount;
        [SerializeField] private AudioSource shootSound;
        protected BulletFactory BulletFactory;
        private float _reloadTime;

        [Inject]
        private void Construct(BulletFactory bulletFactory)
        {
            BulletFactory = bulletFactory;
        }

        protected virtual void Start() => _reloadTime = reloadTime;

        protected virtual void Update() => Reload();

        protected void HandleFire()
        {
            if (ammoAmount <= 0) return;
            SpawnBullet();
            ammoAmount -= 1;
            shootSound.Play();
        }

        protected virtual void SpawnBullet()
        {
            var bullet = BulletFactory.GetPlayerBullet();
            bullet.transform.position = shootPoint.position;
            if (bullet.TryGetComponent(out Rigidbody2D rb))
            {
                rb.velocity = transform.right * bulletSpeed;
            }
        }

        private void Reload()
        {
            if (ammoAmount <= 0)
            {
                _reloadTime -= Time.deltaTime;
            }

            if (!(_reloadTime <= 0)) return;
            ammoAmount = 5;
            _reloadTime = reloadTime;
        }
    }
}