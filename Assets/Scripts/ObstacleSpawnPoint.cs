using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawnPoint : MonoBehaviour
{
    [SerializeField] private GameObject obstacle = null;

    private void Start()
    {
        Instantiate(obstacle, transform.position, Quaternion.identity);
    }
}