using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    private Vector2 _direction;
    private float _speed;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        _direction = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
        _speed = Random.Range(2f, 4f);
        _rigidbody2D.velocity = (_direction * _speed);
    }
}