using UnityEngine;

public abstract class WeaponBase : MonoBehaviour
{
    [SerializeField] private float bulletSpeed;
    [SerializeField] private float reloadTime;
    [SerializeField] private Transform shootPoint;
    [SerializeField] private Rigidbody2D bulletPrefab;
    [SerializeField] private int ammoAmount;
    [SerializeField] private AudioSource shootSound;
    private float _reloadTime;

    protected virtual void Start() => _reloadTime = reloadTime;

    protected virtual void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            HandleFire();
        }

        Reload();
    }

    protected virtual void HandleFire()
    {
        if (ammoAmount <= 0) return;
        var bullet = Instantiate(bulletPrefab, shootPoint.position, transform.rotation);
        bullet.velocity = transform.right * bulletSpeed;
        ammoAmount -= 1;
        shootSound.Play();
    }

    protected void Reload()
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