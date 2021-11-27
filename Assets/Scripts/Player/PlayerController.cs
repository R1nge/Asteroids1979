using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private int lives;
    private UIHandler _uiHandler;
    private Health _health;

    private void Awake()
    {
        _uiHandler = FindObjectOfType<UIHandler>();
        _health = GetComponent<Health>();
        _health.OnDieEvent += Die;
    }

    private void Start()
    {
        _uiHandler.UpdateLivesUI(lives);
    }

    private void Die()
    {
        if (lives <= 1)
        {
            Destroy(gameObject);
            _uiHandler.GameOver();
        }
        else
        {
            Respawn();
        }
    }

    private void Respawn()
    {
        var go = Instantiate(gameObject, new Vector3(0, 0, 0), Quaternion.Euler(0, 0, 90));
        go.GetComponent<PlayerController>().lives -= 1;
        _uiHandler.UpdateLivesUI(lives);
        Destroy(gameObject);
    }
}