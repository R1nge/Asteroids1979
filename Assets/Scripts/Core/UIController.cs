using TMPro;
using UnityEngine;
using VContainer;

namespace Core
{
    public class UIController : MonoBehaviour
    {
        [SerializeField] private UIModel uiModel;
        private UIView _uiView;
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
            _gameManager.OnGameStartedEvent += OnGameStarted;
            _gameManager.OnGameOverEvent += GameOver;
            _scoreHandler.OnScoreUpdated += UpdateScore;
            _scoreHandler.OnHighScoreUpdated += UpdateHighScore;
            _uiView = new(uiModel.score, uiModel.highScore, uiModel.lives, uiModel.mainMenu, uiModel.inGame, uiModel.gameOver);
            _uiView.Initialize();
        }

        private void UpdateScore(int scorePoints)
        {
            _uiView.UpdateUI(ref scorePoints);
        }

        private void UpdateHighScore(int points)
        {
            _uiView.UpdateHighScore(ref points);
        }

        public void UpdateLives(int amount)
        {
            _uiView.UpdateLives(ref amount);
        }

        private void OnGameStarted()
        {
            _uiView.OnGameStarted();
        }

        private void GameOver()
        {
            _uiView.OnGameOver();
        }

        private void OnDestroy()
        {
            _gameManager.OnGameStartedEvent -= OnGameStarted;
            _gameManager.OnGameOverEvent -= GameOver;
            _scoreHandler.OnScoreUpdated -= UpdateScore;
            _scoreHandler.OnHighScoreUpdated -= UpdateScore;
        }
    }
}