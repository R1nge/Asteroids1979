using UnityEngine;

public class ScoreHandler : MonoBehaviour
{
    public int score;
    private int _highScore;
    private UIHandler _uiHandler;

    private void Start()
    {
        _highScore = PlayerPrefs.GetInt("HighScore");
        _uiHandler = FindObjectOfType<UIHandler>();
        print(_highScore);
    }

    public void AddScore(int amount)
    {
        score += amount;
        _uiHandler.UpdateUI(score);
        if (score > _highScore)
        {
            _highScore = score;
            PlayerPrefs.SetInt("HighScore", _highScore);
            PlayerPrefs.Save();
            print(_highScore);
        }
    }
}