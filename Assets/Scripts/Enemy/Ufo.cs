using UnityEngine;

public class Ufo : MonoBehaviour
{
    [SerializeField] private int points;
    [SerializeField] private Weapon weapon;
    private ScoreHandler _scoreHandler;
    private Health _health;

    private void Awake()
    {
        _scoreHandler = FindObjectOfType<ScoreHandler>();
        _health = GetComponent<Health>();
        _health.OnDieEvent += Die;
    }

    private void Start() => weapon.InvokeRepeating("HandleFire", 0, 2);

    private void Die()
    {
        Destroy(gameObject);
        _scoreHandler.AddScore(points);
    }

    private void OnDestroy() => _health.OnDieEvent -= Die;
}