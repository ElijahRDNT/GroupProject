using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private PlayerController playerControllerScript; // Referencing the Player Controller script
    private SpawnManager spawnManagerScript; // Referencing the Spawn Manager script
    private float score = 0;
    // Variables for the game text
    public TextMeshProUGUI titleText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI lifeText;
    public TextMeshProUGUI gameOverText;
    // Variables for the game buttons
    public Button playAgainButton;
    public Button quitButton;
    // Variables for the game screen
    public GameObject titleScreen;
    public GameObject scoreScreen;
    public GameObject lifeScreen;
    public GameObject insScreen;

    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        spawnManagerScript = GameObject.Find("Spawn Manager").GetComponent<SpawnManager>();
    }


    void Update()
    {
        
    }

    public void StartGame() // When you play the game, the score and life text will appear and the spawning of obstacles will start
    {
        scoreScreen.gameObject.SetActive(true);
        lifeScreen.gameObject.SetActive(true);
        playerControllerScript.gameOver = false;
        StartCoroutine(spawnManagerScript.SpeedUpdate());
        StartCoroutine(spawnManagerScript.SpawnRandomObstacles());
        StartCoroutine(UpdateScore());
        titleScreen.gameObject.SetActive(false);
    }

    public void GameOver() // If the game is over, there would be a game over text and a play again and quit button
    {
        scoreScreen.gameObject.SetActive(false);
        lifeScreen.gameObject.SetActive(false);
        gameOverText.gameObject.SetActive(true);
        playAgainButton.gameObject.SetActive(true);
        quitButton.gameObject.SetActive(true);
    }

    
    IEnumerator UpdateScore() // To update the player's score while playing
    {
        while (playerControllerScript.gameOver == false)
        {
            scoreText.text = "SCORE: " + score;
            score += 1;
            yield return new WaitForSeconds(1);
        }
    }

    public void RestartGame() // Making the game start all over again
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Instructions() // Making a certain screen appear in the game
    {
        titleScreen.gameObject.SetActive(false);
        insScreen.gameObject.SetActive(true);
    }

    public void Back() // After reading the instructions, the player will get back to the title screen where he can click the play button
    {
        titleScreen.gameObject.SetActive(true);
        insScreen.gameObject.SetActive(false);
    }
}
