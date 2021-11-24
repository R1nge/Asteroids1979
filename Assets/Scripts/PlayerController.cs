using UnityEngine;

public class PlayerController : MonoBehaviour, IDamageable
{
    [SerializeField] private int health;
    [SerializeField] private float speed;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private Transform shootPoint;
    [SerializeField] private Rigidbody2D bulletPrefab;
    [SerializeField] private int ammoAmount;
    [SerializeField] private float reloadTime;
    [SerializeField] private AudioSource thrustSound, shootSound;
    private float _reloadTime;
    private Rigidbody2D _rigidbody2D;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        _reloadTime = reloadTime;
    }

    private void Update()
    {
        Move();
        Rotate();
        Shoot();
        Reload();
    }


    private void Move()
    {
        if (Input.GetKey(KeyCode.W))
        {
            _rigidbody2D.AddForce(transform.right * speed);
            thrustSound.Play();
        }
    }

    private void Rotate()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0, 0, rotationSpeed);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0, 0, -rotationSpeed);
        }
    }

    private void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (ammoAmount > 0)
            {
                var bullet = Instantiate(bulletPrefab, shootPoint.position, transform.rotation);
                bullet.velocity = (transform.right * speed * 10);
                ammoAmount -= 1;
                shootSound.Play();
            }
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

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.TryGetComponent(out IDamageable damageable))
        {
            damageable.TakeDamage(1);
        }
    }

    public void TakeDamage(int amount)
    {
        health -= amount;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}