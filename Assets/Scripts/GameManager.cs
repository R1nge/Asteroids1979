using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static event Action OnGameStartedEvent;
    public static event Action OnGameOverEvent;

    public static void StartGame() => OnGameStartedEvent?.Invoke();

    public static void GameOver() => OnGameOverEvent?.Invoke();
    public static void SetTimeScale(int amount) => Time.timeScale = amount;

    public static void Restart() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
}
