using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private int lives;
    private Health _health;
    private Rigidbody2D _rigidbody2D;

    public event Action<int> OnTakenDamageEvent;

    private void Awake()
    {
        _health = GetComponent<Health>();
        _health.OnDieEvent += Die;
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }
    
    private void Die()
    {
        if (lives <= 1)
        {
            gameObject.SetActive(false);
            GameManager.GameOver();
        }
        else
        {
            Respawn();
        }
        
        OnTakenDamageEvent?.Invoke(lives);
    }

    private void Respawn()
    {
        _rigidbody2D.velocity = Vector2.zero;
        _rigidbody2D.angularVelocity = 0f;
        gameObject.transform.position = new Vector3(0, 0, 0);
        gameObject.transform.rotation = Quaternion.Euler(0,0,90);
        lives -= 1;
    }

    private void OnDestroy() => _health.OnDieEvent -= Die;
}