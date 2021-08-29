using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public GameObject pauseScreen;

    private bool paused;

    public Button restartButton;
    public Button startButton;
    private PlayerController playerController;
    private AudioSource gameAudio;
    public AudioClip buttonSound;

    private int score;

    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        gameAudio = GetComponent<AudioSource>();
    }

    // method to start the game itself
    public void StartGame()
    {
        gameAudio.PlayOneShot(buttonSound, 1.0f);

        playerController.gameOver = false;

        startButton.gameObject.SetActive(false);

        scoreText.gameObject.SetActive(true);

        // sets score to 0
        score = 0;
        scoreText.text = "Score: " + score;

    }

    // method to call the pause panel and stop the game
    void ChangePaused()
    {
        if (!paused)
        {
            paused = true;
            pauseScreen.SetActive(true);
            Time.timeScale = 0;
        } else
        {
            paused = false;
            pauseScreen.SetActive(false);
            Time.timeScale = 1;
        }
    }


    // Update is called once per frame
    void Update()
    {
        // calls pause method when space is pressed
        if (Input.GetKeyDown(KeyCode.Space)) {

            gameAudio.PlayOneShot(buttonSound, 1.0f);
            ChangePaused();
        }
    }
    // method to update score
    public void UpdateScore()
    {
        score++;
        scoreText.text = "Score: " + score;
    }
    // method to call process when game is over
    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
    }

    // method to restart the game
    public void RestartGame()
    {
        gameAudio.PlayOneShot(buttonSound, 1.0f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
