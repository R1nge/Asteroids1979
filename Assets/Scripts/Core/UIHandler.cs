using TMPro;
using UnityEngine;

namespace Core
{
    public class UIHandler : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI score, highScore, lives;
        [SerializeField] private Canvas mainMenu, inGame, gameOver;

        private void Awake()
        {
            GameManager.Instance.OnGameStartedEvent += Play;
            GameManager.Instance.OnGameOverEvent += GameOver;
            ScoreHandler.Instance.OnScoreUpdated += UpdateScore;
            ScoreHandler.Instance.OnHighScoreUpdated += UpdateHighScore;
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
            GameManager.Instance.OnGameStartedEvent -= Play;
            GameManager.Instance.OnGameOverEvent -= GameOver;
            ScoreHandler.Instance.OnScoreUpdated -= UpdateScore;
            ScoreHandler.Instance.OnHighScoreUpdated -= UpdateScore;
        }
    }
}