using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public AudioClip bonusSound;
    public AudioClip crashSound;
    private AudioSource playerAudio;

    private float speed = 5;
    private float horizontalInput;
    private float xRange = 4;
    public bool gameOver;

    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        playerAudio = GetComponent<AudioSource>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

    }

    // Update is called once per frame
    void Update()
    {
        // moves player to the right and left

        if (!gameOver) {

            horizontalInput = Input.GetAxis("Horizontal");

            transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput);
        }
        

        // keeps player on the road

        if (transform.position.x > xRange)
        {
            transform.position = new Vector3 (xRange, transform.position.y, transform.position.z);
        }
        else if (transform.position.x < - xRange)
        {
            transform.position = new Vector3 (- xRange, transform.position.y, transform.position.z);
        } 
       
    }

    // detects if player has collission with bonus and destroys it or with an obstacle than game is over

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bonus"))
        {
            Destroy(collision.gameObject);
            gameManager.UpdateScore();
            playerAudio.PlayOneShot(bonusSound, 1.0f);
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            playerAudio.PlayOneShot(crashSound, 1.0f);
            gameOver = true;
            gameManager.GameOver();
        }
    }
}
