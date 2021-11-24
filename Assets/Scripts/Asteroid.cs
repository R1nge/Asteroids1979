using UnityEngine;

public class Asteroid : MonoBehaviour, IDamageable
{
    [SerializeField] private int health;
    [SerializeField] private GameObject[] asteroids;
    private Rigidbody2D _rigidbody2D;
    private Vector2 _direction;
    private float _speed;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        _direction = new Vector2(Random.Range(-5, 5), Random.Range(-6, 6));
        _speed = Random.Range(.5f, 1f);
        _rigidbody2D.velocity = (_direction * _speed);
    }

    private void DestroyObject()
    {
        foreach (var asteroid in asteroids)
        {
            Instantiate(asteroid, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }

    public void TakeDamage(int amount)
    {
        health -= amount;
        if (health <= 0)
        {
            DestroyObject();
        }
    }
}