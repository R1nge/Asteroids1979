using UnityEngine;

public class ScoreHandler : MonoBehaviour
{
    private int _score;
    private int _highScore;
    private UIHandler _uiHandler;

    private void Awake()
    {
        _highScore = PlayerPrefs.GetInt("HighScore");
        _uiHandler = FindObjectOfType<UIHandler>();
    }

    private void Start()
    {
        _uiHandler.UpdateUI(_score, _highScore);
    }

    public void AddScore(int amount)
    {
        _score += amount;
        _uiHandler.UpdateUI(_score, _highScore);
        if (_score > _highScore)
        {
            _highScore = _score;
            PlayerPrefs.SetInt("HighScore", _highScore);
            PlayerPrefs.Save();
        }
    }
}