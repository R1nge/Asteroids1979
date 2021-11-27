using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [SerializeField] private GameObject[] asteroids;
    [SerializeField] private int points;
    private ScoreHandler _scoreHandler;
    private Health _health;

    private void Awake()
    {
        _scoreHandler = FindObjectOfType<ScoreHandler>();
        _health = GetComponent<Health>();
        _health.OnDieEvent += DestroyObject;
    }

    private void DestroyObject()
    {
        foreach (var asteroid in asteroids)
        {
            Instantiate(asteroid, transform.position, transform.rotation);
        }

        _scoreHandler.AddScore(points);
        Destroy(gameObject);
    }
}