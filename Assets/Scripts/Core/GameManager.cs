using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Core
{
    public class GameManager
    {
        public event Action OnGameStartedEvent;
        public event Action OnGameOverEvent;

        public void StartGame()
        {
            OnGameStartedEvent?.Invoke();
            SetTimeScale(1);
        }

        public void GameOver()
        {
            OnGameOverEvent?.Invoke();
            SetTimeScale(0);
        }

        private void SetTimeScale(int amount) => Time.timeScale = amount;

        public void Restart() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}