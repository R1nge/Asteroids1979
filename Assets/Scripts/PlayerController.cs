using UnityEngine;


public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private Rigidbody2D bulletPrefab;
    [SerializeField] private int ammoAmount;
    [SerializeField] private float reloadTime;
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
        BorderCheck();
        Rotate();
        Shoot();

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

    private void Move()
    {
        if (Input.GetKey(KeyCode.W))
        {
            _rigidbody2D.AddForce(transform.right * speed);
        }
    }

    private void BorderCheck()
    {
        //Left
        if (transform.position.x < -6.5f)
        {
            transform.position = new Vector3(6.5f, transform.position.y, transform.position.z);
        }

        //Right 
        if (transform.position.x > 6.5f)
        {
            transform.position = new Vector3(-6.5f, transform.position.y, transform.position.z);
        }

        //Bottom
        if (transform.position.y < -5)
        {
            transform.position = new Vector3(transform.position.x, 5, transform.position.z);
        }

        //Top
        if (transform.position.y > 5)
        {
            transform.position = new Vector3(transform.position.x, -5, transform.position.z);
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
                var bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
                bullet.velocity = (transform.right * speed * 10);
                ammoAmount -= 1;
            }
        }
    }
}