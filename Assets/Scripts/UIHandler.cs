using TMPro;
using UnityEngine;

public class UIHandler : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI score, highScore, lives;
    [SerializeField] private Canvas mainMenu, inGame, gameOver;
    private ScoreHandler _scoreHandler;
    private PlayerController _player;
    
    private void Awake()
    {
        GameManager.OnGameStartedEvent += Play;
        GameManager.OnGameOverEvent += GameOver;
        _scoreHandler = FindObjectOfType<ScoreHandler>();
        _scoreHandler.OnScoreUpdated += UpdateScore;
        _scoreHandler.OnHighScoreUpdated += UpdateHighScore;
        _player = FindObjectOfType<PlayerController>();
        _player.OnTakenDamageEvent += UpdateLives;
    }

    private void Start()
    {
        GameManager.SetTimeScale(0);
        mainMenu.gameObject.SetActive(true);
        inGame.gameObject.SetActive(false);
        gameOver.gameObject.SetActive(false);
    }

    private void UpdateScore(int scorePoints) => score.text = "Score: " + scorePoints;

    private void UpdateHighScore(int points) => highScore.text = "HighScore: " + points;

    private void UpdateLives(int amount) => lives.text = "Lives: " + amount;

    private void Play()
    {
        GameManager.SetTimeScale(1);
        mainMenu.gameObject.SetActive(false);
        inGame.gameObject.SetActive(true);
        gameOver.gameObject.SetActive(false);
    }

    private void GameOver()
    {
        GameManager.SetTimeScale(0);
        mainMenu.gameObject.SetActive(false);
        inGame.gameObject.SetActive(false);
        gameOver.gameObject.SetActive(true);
    }

    private void OnDestroy()
    {
        GameManager.OnGameStartedEvent -= Play;
        GameManager.OnGameOverEvent -= GameOver;
        _scoreHandler.OnScoreUpdated -= UpdateScore;
        _scoreHandler.OnHighScoreUpdated -= UpdateScore;
        _player.OnTakenDamageEvent -= UpdateLives;
    }
}