using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] obstaclePatterns = null;
    [SerializeField] private float startTimeBetweenSpawn = 2f;
    [SerializeField] private float decreaseTime = 0.05f;
    [SerializeField] private float minTime = 0.65f;

    private float timeBetweenSpawn;

    private void Update()
    {
        if (timeBetweenSpawn <= 0)
        {
            int random = Random.Range(0, obstaclePatterns.Length);
            Instantiate(obstaclePatterns[random], transform.position, Quaternion.identity);
            timeBetweenSpawn = startTimeBetweenSpawn;

            if (startTimeBetweenSpawn > minTime)
            {
                startTimeBetweenSpawn -= decreaseTime;
            }
        }
        else
        {
            timeBetweenSpawn -= Time.deltaTime;
        }
    }
}