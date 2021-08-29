using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject obstacle;
    private PlayerController playerController;

    private float xPos;
    private float xRange = 3;
    private float yPos = 0.5f;
    private float zPos = 80;
    private float startTime = 1;
    private float repeatRate = 1f;

    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();

        // starts instantion of obstacles

        InvokeRepeating("SpawnAnObstacle", startTime, repeatRate);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //method for creating obstcles at random x range
    void SpawnAnObstacle()
    {
        if (playerController.gameOver != true)
        {
            xPos = Random.Range(-xRange, xRange);
            Vector3 spawnPos = new Vector3(xPos, yPos, zPos);
            Instantiate(obstacle, spawnPos, obstacle.transform.rotation);
        }
        
    }
}
