using UnityEngine;

public class ScoreHandler : MonoBehaviour
{
    public int score;
    private int _highScore;
    private UIHandler _uiHandler;

    private void Awake()
    {
        _highScore = PlayerPrefs.GetInt("HighScore");
        _uiHandler = FindObjectOfType<UIHandler>();
    }

    private void Start()
    {
        _uiHandler.UpdateUI(score, _highScore);
    }

    public void AddScore(int amount)
    {
        score += amount;
        _uiHandler.UpdateUI(score, _highScore);
        if (score > _highScore)
        {
            _highScore = score;
            PlayerPrefs.SetInt("HighScore", _highScore);
            PlayerPrefs.Save();
        }
    }
}