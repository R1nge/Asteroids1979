using Core;
using UnityEngine;
using VContainer;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private int lives;
        private Health _health;
        private Rigidbody2D _rigidbody2D;
        private GameManager _gameManager;
        private UIController uiController;

        [Inject]
        private void Construct(GameManager gameManager, UIController uiController)
        {
            _gameManager = gameManager;
            this.uiController = uiController;
        }

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
                _gameManager.GameOver();
            }
            else
            {
                Respawn();
            }

            uiController.UpdateLives(lives);
        }

        private void Respawn()
        {
            _rigidbody2D.velocity = Vector2.zero;
            _rigidbody2D.angularVelocity = 0f;
            transform.position = Vector3.zero;
            transform.rotation = Quaternion.Euler(0, 0, 90f);
            lives -= 1;
        }

        private void OnDestroy() => _health.OnDieEvent -= Die;
    }
}