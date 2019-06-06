using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class Player : MonoBehaviour
{
    [SerializeField] private float yIncrement = 5f;
    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private int health = 3;
    [SerializeField] private GameObject moveEffect = null;
    [SerializeField] private GameObject moveSound = null;

    public event Action<int> OnHitByObstacle;

    private GameManager gameManager;
    private CameraController cameraController;
    private float topY;
    private float bottomY;
    private Vector2 destination;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        cameraController = FindObjectOfType<CameraController>();
    }

    private void Start()
    {
        topY = yIncrement;
        bottomY = -yIncrement;

        destination = transform.position;
        gameManager.OnGameOver += GameOver;
    }

    private void Update()
    {
        if (destination != (Vector2) transform.position)
        {
            transform.position = Vector3.MoveTowards(transform.position, destination, moveSpeed * Time.deltaTime);
        }
    }

    public void MoveUp()
    {
        if (destination.y < topY)
        {
            MoveY(yIncrement);
        }
    }

    public void MoveDown()
    {
        if (destination.y > bottomY)
        {
            MoveY(-yIncrement);
        }
    }

    private void MoveY(float increment)
    {
        Instantiate(moveEffect, transform.position, Quaternion.identity);
        Instantiate(moveSound, transform.position, Quaternion.identity);
        cameraController.CameraShake();
        destination = new Vector2(transform.position.x, destination.y + increment);
    }

    public void HitByObstacle(int damage)
    {
        health -= damage;
        OnHitByObstacle?.Invoke(health);
    }

    public int GetHealth()
    {
        return health;
    }

    private void GameOver()
    {
        Destroy(gameObject);
    }
}