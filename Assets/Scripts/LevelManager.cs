using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [Header("Main")]
    public int score;
    public int health = 3;
    
    [Header("Events")]
    public UnityEvent<int> changeScoreEvent;
    public UnityEvent<int> changeHealthEvent;
    public UnityEvent gameOverEvent;

    private void Start()
    {
        gameOverEvent.AddListener(GameOverSubscriber);
    }

    public void AddScore(int addScore)
    {
        score += addScore;
        
        changeScoreEvent?.Invoke(score);
    }

    public int GetScore()
    {
        return score;
    }

    public void AddHealth(int addHealth)
    {
        health += addHealth;
        
        changeHealthEvent?.Invoke(health);
        
        if (health <= 0)
        {
            gameOverEvent?.Invoke();
        }
    }

    public int GetHealth()
    {
        return health;
    }

    public void LoadLevel(string nameLevel)
    {
        SceneManager.LoadScene(nameLevel);
    }

    private void GameOverSubscriber()
    {
        Time.timeScale = 0f;
    }

    public void CheckOutObjects(Collider2D other)
    {
        AddHealth(-1);
            
        Destroy(other.gameObject);
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        
        LoadLevel("Main");
    }
}
