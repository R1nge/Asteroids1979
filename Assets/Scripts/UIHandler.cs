using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIHandler : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI score, highScore, lives;
    [SerializeField] private GameObject startScreen;
    [SerializeField] private GameObject gameOverScreen;
    private Spawner _spawner;

    private void Awake()
    {
        _spawner = GetComponent<Spawner>();
    }

    private void Start()
    {
        Time.timeScale = 0;
        _spawner.enabled = false;
        gameOverScreen.SetActive(false);
    }

    public void UpdateScoreUI(int scorePoints, int highScorePoints)
    {
        score.text = "Score: " + scorePoints;
        highScore.text = "HighScore: " + highScorePoints;
    }

    public void UpdateLivesUI(int amount)
    {
        lives.text = amount.ToString();
    }

    public void Play()
    {
        startScreen.SetActive(false);
        _spawner.enabled = true;
        Time.timeScale = 1;
    }

    public void GameOver()
    {
        score.gameObject.SetActive(false);
        gameOverScreen.SetActive(true);
        _spawner.enabled = false;
        Time.timeScale = 0;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}