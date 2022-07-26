using System;
using UnityEngine;

namespace Core
{
    public class ScoreHandler : MonoBehaviour
    {
        private int _score, _highScore;

        public event Action<int> OnScoreUpdated;
        public event Action<int> OnHighScoreUpdated;

        public static ScoreHandler Instance
        {
            get
            {
                if (_instance == null)
                    _instance = FindObjectOfType(typeof(ScoreHandler)) as ScoreHandler;

                return _instance;
            }
            private set => _instance = value;
        }

        private static ScoreHandler _instance;

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