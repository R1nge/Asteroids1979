using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIHandler : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI score, highScore;
    [SerializeField] private GameObject startScreen;
    [SerializeField] private GameObject gameOverScreen;

    private void Start()
    {
        Time.timeScale = 0;
        gameOverScreen.SetActive(false);
    }

    public void UpdateUI(int scorePoints, int highScorePoints)
    {
        score.text = "Score: " + scorePoints;
        highScore.text = "HighScore: " + highScorePoints;
    }

    public void Play()
    {
        startScreen.SetActive(false);
        Time.timeScale = 1;
    }

    public void GameOver()
    {
        score.gameObject.SetActive(false);
        gameOverScreen.SetActive(true);
        Time.timeScale = 0;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}