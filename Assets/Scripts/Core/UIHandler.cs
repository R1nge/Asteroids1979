using TMPro;
using UnityEngine;
using VContainer;

namespace Core
{
    public class UIHandler : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI score, highScore, lives;
        [SerializeField] private Canvas mainMenu, inGame, gameOver;
        private GameManager _gameManager;
        private ScoreHandler _scoreHandler;

        [Inject]
        private void Construct(GameManager gameManager, ScoreHandler scoreHandler)
        {
            _gameManager = gameManager;
            _scoreHandler = scoreHandler;
        }

        public void StartGame() => _gameManager.StartGame();

        public void Restart() => _gameManager.Restart();

        private void Start()
        {
            _gameManager.OnGameStartedEvent += Play;
            _gameManager.OnGameOverEvent += GameOver;
            _scoreHandler.OnScoreUpdated += UpdateScore;
            _scoreHandler.OnHighScoreUpdated += UpdateHighScore;
            mainMenu.gameObject.SetActive(true);
            inGame.gameObject.SetActive(false);
            gameOver.gameObject.SetActive(false);
        }

        private void UpdateScore(int scorePoints) => score.text = $"Score: {scorePoints}";

        private void UpdateHighScore(int points) => highScore.text = $"HighScore: {points}";

        public void UpdateLives(int amount) => lives.text = $"Lives: {amount}";

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
            _gameManager.OnGameStartedEvent -= Play;
            _gameManager.OnGameOverEvent -= GameOver;
            _scoreHandler.OnScoreUpdated -= UpdateScore;
            _scoreHandler.OnHighScoreUpdated -= UpdateScore;
        }
    }
}