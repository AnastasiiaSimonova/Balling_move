using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class BonusManager : MonoBehaviour
{

    private float xRange = 4;
    private float yPos = 0.6f;
    private float zPos = 80;

    public GameObject bonus;
    private PlayerController playerController;

    private float startTime = 3;
    private float repeatRate = 3;

    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();

        // starts instantiation of bonuses
        InvokeRepeating("BonusSpawn", startTime, repeatRate);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // method to create bonuses at random x Range
    void BonusSpawn()
    {
        if (playerController.gameOver != true)
        {
            float xPos = Random.Range(-xRange, xRange);
            Vector3 spawnPos = new Vector3(xPos, yPos, zPos);
            Instantiate(bonus, spawnPos, bonus.transform.rotation);
        }
        
    }
}
