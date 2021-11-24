using TMPro;
using UnityEngine;

public class UIHandler : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI score;

    private void Start()
    {
        UpdateUI(0);
    }

    public void UpdateUI(int points)
    {
        score.text = points.ToString();
    }
}