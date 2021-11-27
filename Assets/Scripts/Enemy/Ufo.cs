using UnityEngine;

public class Ufo : MonoBehaviour, IDamageable
{
    [SerializeField] private int points;
    [SerializeField] private int lives;
    [SerializeField] private Weapon weapon;
    private ScoreHandler _scoreHandler;

    private void Awake()
    {
        _scoreHandler = FindObjectOfType<ScoreHandler>();
    }

    private void Start()
    {
        weapon.InvokeRepeating("HandleFire", 0, 2);
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