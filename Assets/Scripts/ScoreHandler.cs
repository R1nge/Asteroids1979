using System;
using UnityEngine;

public class ScoreHandler : MonoBehaviour
{
    private int _score;
    private int _highScore;

    public event Action<int> OnScoreUpdated;
    public event Action<int> OnHighScoreUpdated;

    private void Awake() => _highScore = PlayerPrefs.GetInt("HighScore");


    public void AddScore(int amount)
    {
        _score += amount;
        OnScoreUpdated?.Invoke(_score);
        if (_score <= _highScore) return;
        _highScore = _score;
        OnHighScoreUpdated?.Invoke(_highScore);
        PlayerPrefs.SetInt("HighScore", _highScore);
        PlayerPrefs.Save();
    }
}