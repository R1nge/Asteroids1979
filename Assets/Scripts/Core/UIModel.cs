using System;
using TMPro;
using UnityEngine;

namespace Core
{
    [Serializable]
    public class UIModel
    {
        public TextMeshProUGUI score, highScore, lives;
        public Canvas mainMenu, inGame, gameOver;
    }
}