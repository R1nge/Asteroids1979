using UnityEngine;

public class Ufo : MonoBehaviour, IDamageable
{
    [SerializeField] private int points;
    [SerializeField] private int lives;
    [SerializeField] private float reloadTime;
    [SerializeField] private float bulletSpeed;
    [SerializeField] private Transform shootPoint;
    [SerializeField] private Rigidbody2D bulletPrefab;
    private Rigidbody2D _rigidbody2D;
    private float _reloadTime;
    private Vector2 _direction;
    private float _speed;
    private ScoreHandler _scoreHandler;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _scoreHandler = FindObjectOfType<ScoreHandler>();
    }

    private void Start()
    {
        _direction = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
        _speed = Random.Range(2f, 4f);
        _rigidbody2D.velocity = (_direction * _speed);
    }

    private void Update()
    {
        _reloadTime -= Time.deltaTime;
        if (_reloadTime <= 0)
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        var bullet = Instantiate(bulletPrefab, shootPoint.position, shootPoint.rotation);
        bullet.velocity = (shootPoint.transform.right * bulletSpeed * 10);
        _reloadTime = reloadTime;
    }

    public void TakeDamage(int amount)
    {
        lives -= 1;
        if (lives <= 0)
        {
            Destroy(gameObject);
            _scoreHandler.AddScore(points);
        }
    }
}