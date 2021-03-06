﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private int damage = 1;
    [SerializeField] private float speed = 5f;
    [SerializeField] private GameObject deadEffect = null;
    [SerializeField] private GameObject deadSound = null;

    private CameraController cameraController;

    private void Start()
    {
        cameraController = FindObjectOfType<CameraController>();
    }

    private void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            cameraController.CameraShake();
            Instantiate(deadEffect, transform.position, Quaternion.identity);
            Instantiate(deadSound, transform.position, Quaternion.identity);
            other.GetComponent<Player>().HitByObstacle(damage);
            Destroy(gameObject);
        }
    }
}