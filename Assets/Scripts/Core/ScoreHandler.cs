using System;
using UnityEngine;

namespace Core
{
    public class ScoreHandler : MonoBehaviour
    {
        private int _score, _highScore;

        public event Action<int> OnScoreUpdated;
        public event Action<int> OnHighScoreUpdated;

        private void Awake() => Load();

        private void Load()
        {
            _highScore = PlayerPrefs.GetInt("HighScore");
            UpdateScore();
        }

        public void AddScore(int amount)
        {
            _score += amount;
            UpdateScore();
            SetHighScore();
            Save();
        }

        private void UpdateScore()
        {
            OnScoreUpdated?.Invoke(_score);
            OnHighScoreUpdated?.Invoke(_highScore);
        }

        private void SetHighScore()
        {
            if (_score <= _highScore) return;
            _highScore = _score;
        }

        private void Save()
        {
            PlayerPrefs.SetInt("HighScore", _highScore);
            PlayerPrefs.Save();
        }
    }
}