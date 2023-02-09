using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    public AudioClip bgMusic;
    private Vector3 offset = new Vector3(0, 9, -10);
    private AudioSource gameAudio;
    private PlayerController playerControllerScript; // Referencing the Player Controller script


    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        gameAudio = GetComponent<AudioSource>();
        gameAudio.clip = bgMusic;
        gameAudio.Play(); // Adding a background music when you play the game
    }


    void LateUpdate()
    {
        transform.position = player.transform.position + offset; // Making the main camera follow the player
    }

    void Update()
    {
        if (playerControllerScript.gameOver == true) // If the game is over, the background music will stop
        {
            gameAudio.Stop();
        }
    }
}
