using TMPro;
using UnityEngine;

namespace Core
{
    public class UIHandler : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI score, highScore, lives;
        [SerializeField] private Canvas mainMenu, inGame, gameOver;
        private ScoreHandler _scoreHandler;

        private void Awake()
        {
            GameManager.Instance.OnGameStartedEvent += Play;
            GameManager.Instance.OnGameOverEvent += GameOver;
            _scoreHandler = FindObjectOfType<ScoreHandler>();
            _scoreHandler.OnScoreUpdated += UpdateScore;
            _scoreHandler.OnHighScoreUpdated += UpdateHighScore;
        }

        private void Start()
        {
            mainMenu.gameObject.SetActive(true);
            inGame.gameObject.SetActive(false);
            gameOver.gameObject.SetActive(false);
        }

        private void UpdateScore(int scorePoints) => score.text = "Score: " + scorePoints;

        private void UpdateHighScore(int points) => highScore.text = "HighScore: " + points;

        public void UpdateLives(int amount) => lives.text = "Lives: " + amount;

        private void Play()
        {
            mainMenu.gameObject.SetActive(false);
            inGame.gameObject.SetActive(true);
            gameOver.gameObject.SetActive(false);
        }

        private void GameOver()
        {
            mainMenu.gameObject.SetActive(false);
            inGame.gameObject.SetActive(false);
            gameOver.gameObject.SetActive(true);
        }

        private void OnDestroy()
        {
            _scoreHandler.OnScoreUpdated -= UpdateScore;
            _scoreHandler.OnHighScoreUpdated -= UpdateScore;
        }
    }
}