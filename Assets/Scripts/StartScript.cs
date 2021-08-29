using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartScript : MonoBehaviour
{
    private Button button;
    private GameManager gameManager;
    private PlayerController playerController;

    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        playerController.gameOver = true;

        button = GetComponent<Button>();
        button.onClick.AddListener(RunTheGame);

        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void RunTheGame()
    {
        gameManager.StartGame();
    }
}
