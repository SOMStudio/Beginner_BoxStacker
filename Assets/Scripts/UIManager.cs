using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    [SerializeField] private Text healthText;
    [SerializeField] private GameObject gameOverPanel;
    
    public void UpdateScore(int newScore)
    {
        scoreText.text = newScore.ToString();
    }

    public void UpdateHealth(int newHealth)
    {
        healthText.text = newHealth.ToString();
    }

    public void GameOver()
    {
        gameOverPanel.SetActive(true);
    }
}
