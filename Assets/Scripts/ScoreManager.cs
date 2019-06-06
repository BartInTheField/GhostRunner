using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private GameManager gameManager;
    private bool gameOver = false;
    private int score;

    public event Action<int> OnScoreChange;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void Start()
    {
        gameManager.OnGameOver += SetGameOver;
    }

    private void SetGameOver()
    {
        gameOver = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Obstacle") && !gameOver)
        {
            score++;
            OnScoreChange?.Invoke(score);
        }
    }
}