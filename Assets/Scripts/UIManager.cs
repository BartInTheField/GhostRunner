using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI healthText = null;
    [SerializeField] private TextMeshProUGUI scoreText = null;
    [SerializeField] private GameObject gameOver = null;

    private GameManager gameManager;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void Start()
    {
        SetScoreText(0);
        SetHealthText(gameManager.GetPlayerHealth());

        gameManager.OnHealthChange += SetHealthText;
        gameManager.OnScoreChange += SetScoreText;
        gameManager.OnGameOver += SetGameOver;
    }

    private void SetHealthText(int health)
    {
        healthText.text = health.ToString();
    }

    private void SetScoreText(int score)
    {
        scoreText.text = score.ToString();
    }

    private void SetGameOver()
    {
        gameOver.SetActive(true);
    }
}