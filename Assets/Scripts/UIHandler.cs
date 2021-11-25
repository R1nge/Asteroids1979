using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIHandler : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI score, highScore;
    [SerializeField] private GameObject gameOverScreen;

    private void Start()
    {
        gameOverScreen.SetActive(false);
    }

    public void UpdateUI(int scorePoints, int highScorePoints)
    {
        score.text = "Score: " + scorePoints;
        highScore.text = "HighScore: " + highScorePoints;
    }

    public void GameOver()
    {
        score.gameObject.SetActive(false);
        gameOverScreen.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}