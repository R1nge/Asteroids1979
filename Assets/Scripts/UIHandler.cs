using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIHandler : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI score, highScore, lives;
    [SerializeField] private Canvas mainMenu, inGame, gameOver;
    private Spawner _spawner;

    private void Awake()
    {
        _spawner = GetComponent<Spawner>();
    }

    private void Start()
    {
        Time.timeScale = 0;
        _spawner.enabled = false;
        mainMenu.gameObject.SetActive(true);
        inGame.gameObject.SetActive(false);
        gameOver.gameObject.SetActive(false);
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
        mainMenu.gameObject.SetActive(false);
        inGame.gameObject.SetActive(true);
        gameOver.gameObject.SetActive(false);
        _spawner.enabled = true;
        Time.timeScale = 1;
    }

    public void GameOver()
    {
        mainMenu.gameObject.SetActive(false);
        inGame.gameObject.SetActive(false);
        gameOver.gameObject.SetActive(true);
        _spawner.enabled = false;
        Time.timeScale = 0;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}