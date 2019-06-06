using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private Player player;
    private ScoreManager scoreManager;
    private bool gameOver = false;

    public event Action<int> OnScoreChange;
    public event Action<int> OnHealthChange;

    public event Action OnGameOver;

    private void Awake()
    {
        player = FindObjectOfType<Player>();
        scoreManager = FindObjectOfType<ScoreManager>();
    }

    private void Start()
    {
        scoreManager.OnScoreChange += ScoreChanged;
        player.OnHitByObstacle += PlayerHitByObstacle;
    }

    private void Update()
    {
        if (!gameOver)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                player.MoveUp();
            }

            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                player.MoveDown();
            }
        }
    }

    private void ScoreChanged(int score)
    {
        OnScoreChange?.Invoke(score);
    }

    private void PlayerHitByObstacle(int currentHealth)
    {
        OnHealthChange?.Invoke(currentHealth);
        if (currentHealth <= 0)
        {
            gameOver = true;
            OnGameOver?.Invoke();
        }
    }

    public int GetPlayerHealth()
    {
        return player.GetHealth();
    }
}