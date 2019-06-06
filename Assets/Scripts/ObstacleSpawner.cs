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

    private void Start()
    {
        StartCoroutine(StartSpawn(startTimeBetweenSpawn));
    }

    private IEnumerator StartSpawn(float waitTime)
    {
        int random = Random.Range(0, obstaclePatterns.Length);
        Instantiate(obstaclePatterns[random], transform.position, Quaternion.identity);


        yield return new WaitForSeconds(waitTime);

        if (waitTime > minTime)
        {
            waitTime -= decreaseTime;
        }

        StartCoroutine(StartSpawn(waitTime));
    }
}