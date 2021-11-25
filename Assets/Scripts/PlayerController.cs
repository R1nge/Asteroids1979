using UnityEngine;

public class PlayerController : MonoBehaviour, IDamageable
{
    public int lives;
    [SerializeField] private float speed;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private Transform shootPoint;
    [SerializeField] private Rigidbody2D bulletPrefab;
    [SerializeField] private int ammoAmount;
    [SerializeField] private float bulletSpeed;
    [SerializeField] private float reloadTime;
    [SerializeField] private AudioSource thrustSound, shootSound;
    private float _reloadTime;
    private Rigidbody2D _rigidbody2D;
    private UIHandler _uiHandler;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _uiHandler = FindObjectOfType<UIHandler>();
    }

    private void Start()
    {
        _reloadTime = reloadTime;
        _uiHandler.UpdateLivesUI(lives);
    }

    private void Update()
    {
        Rotate();
        Shoot();
        Reload();
    }

    private void FixedUpdate()
    {
        Move();
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
                bullet.velocity = (transform.right * bulletSpeed);
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

    private void Respawn()
    {
        var go = Instantiate(gameObject, new Vector3(0, 0, 0), Quaternion.Euler(0, 0, 90));
        _uiHandler.UpdateLivesUI(lives);
        Destroy(gameObject);
        print("Respawn");
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.TryGetComponent(out IDamageable damageable))
        {
            damageable.TakeDamage(1);
        }

        TakeDamage(1);
    }
                                                                                                                                                                                                                                                                                        
    public void TakeDamage(int amount)
    {
        lives -= amount;
        if (lives <= 0)
        {
            Destroy(gameObject);
            _uiHandler.GameOver();
        }
        else
        {
            Respawn();
        }
    }
}