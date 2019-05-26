using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Player player = null;

    private void Start()
    {
        player.OnHitByObstacle += PlayerHitByObstacle;
    }

    private void Update()
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

    private void PlayerHitByObstacle(int currentHealth)
    {
        if (currentHealth <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}