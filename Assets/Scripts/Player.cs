using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float yIncrement = 5f;
    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private int health = 3;

    public event Action<int> OnHitByObstacle;

    private float maxHeight;
    private float minHeight;

    private Vector2 destination;

    private void Start()
    {
        maxHeight = yIncrement;
        minHeight = -yIncrement;

        destination = transform.position;
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
        if (transform.position.y < maxHeight)
        {
            MoveY(yIncrement);
        }
    }

    public void MoveDown()
    {
        if (transform.position.y > minHeight)
        {
            MoveY(-yIncrement);
        }
    }

    private void MoveY(float increment)
    {
        destination = new Vector2(transform.position.x, destination.y + increment);
    }

    public void HitByObstacle(int damage)
    {
        health -= damage;
        OnHitByObstacle?.Invoke(health);
    }
}