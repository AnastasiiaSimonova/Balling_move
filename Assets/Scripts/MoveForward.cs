using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{

    private float speed = 10;
    private float zRange = -3;
    private PlayerController playerController;

    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        // moves things towards player

        if (playerController.gameOver != true) {

            transform.Translate(Vector3.back * Time.deltaTime * speed);

            if (transform.position.z < zRange)
            {
                Destroy(gameObject);
            }
        }

        
    }

    // destroys bonuses if they have collided with obstacles

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bonus"))
        {
            Destroy(collision.gameObject);
           
        }
    }
}
