using UnityEngine;

namespace Weapons
{
    public abstract class WeaponBase : MonoBehaviour
    {
        [SerializeField] private float bulletSpeed;
        [SerializeField] private float reloadTime;
        [SerializeField] private Transform shootPoint;
        [SerializeField] private Rigidbody2D bulletPrefab;
        [SerializeField] private int ammoAmount;
        [SerializeField] private AudioSource shootSound;
        private float _reloadTime;
        private BulletSpawner _bulletSpawner;

        protected virtual void Awake() => _bulletSpawner = FindObjectOfType<BulletSpawner>();

        protected virtual void Start() => _reloadTime = reloadTime;

        protected virtual void Update() => Reload();

        protected void HandleFire()
        {
            if (ammoAmount <= 0) return;
            var bullet = _bulletSpawner.Spawn(bulletPrefab, shootPoint.position, transform.rotation);
            bullet.velocity = transform.right * bulletSpeed;
            ammoAmount -= 1;
            shootSound.Play();
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