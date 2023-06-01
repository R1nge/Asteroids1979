using TMPro;
using UnityEngine;

namespace Core
{
    public class UIView
    {
        private readonly TextMeshProUGUI _score, _highScore, _lives;
        private readonly Canvas _mainMenu, _inGame, _gameOver;

        public UIView(TextMeshProUGUI score, TextMeshProUGUI highScore, TextMeshProUGUI lives, Canvas mainMenu, Canvas inGame, Canvas gameOver)
        {
            _score = score;
            _highScore = highScore;
            _lives = lives;
            _mainMenu = mainMenu;
            _inGame = inGame;
            _gameOver = gameOver;
        }
        
        public void Initialize()
        {
            _mainMenu.gameObject.SetActive(true);
            _inGame.gameObject.SetActive(false);
            _gameOver.gameObject.SetActive(false);
        }

        public void OnGameStarted()
        {
            _mainMenu.gameObject.SetActive(false);
            _inGame.gameObject.SetActive(true);
            _gameOver.gameObject.SetActive(false);
        }

        public void UpdateUI(ref int score)
        {
            _score.text = $"Score: {score}";
        }

        public void UpdateHighScore(ref int points)
        {
            _highScore.text = $"High Score: {points}";
        }

        public void UpdateLives(ref int amount)
        {
            _lives.text = $"Lives: {amount}";
        }

        public void OnGameOver()
        {
            _mainMenu.gameObject.SetActive(false);
            _inGame.gameObject.SetActive(false);
            _gameOver.gameObject.SetActive(true);
        }
    }
}