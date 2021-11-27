using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private float bulletSpeed;
    [SerializeField] private float reloadTime;
    [SerializeField] private Transform shootPoint;
    [SerializeField] private Rigidbody2D bulletPrefab;
    [SerializeField] private int ammoAmount;
    [SerializeField] private AudioSource shootSound;
    private float _reloadTime;

    private void Awake()
    {
        FindObjectOfType<PlayerInput>().OnFife += HandleFire;
    }

    private void Start()
    {
        _reloadTime = reloadTime;
    }

    private void Update()
    {
        Reload();
    }

    private void HandleFire()
    {
        if (ammoAmount > 0)
        {
            var bullet = Instantiate(bulletPrefab, shootPoint.position, transform.rotation);
            bullet.velocity = (transform.right * bulletSpeed);
            ammoAmount -= 1;
            shootSound.Play();
        }
    }

    private void Reload()
    {
        if (ammoAmount <= 0)
        {
            _reloadTime -= Time.deltaTime;
        }

        if (_reloadTime <= 0)
        {
            ammoAmount = 5;
            _reloadTime = reloadTime;
        }
    }
}