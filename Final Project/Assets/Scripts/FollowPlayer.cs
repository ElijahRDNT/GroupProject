using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    public AudioClip bgMusic;
    private Vector3 offset = new Vector3(0, 9, -10);
    private AudioSource gameAudio;
    private PlayerController playerControllerScript;

    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        gameAudio = GetComponent<AudioSource>();
        gameAudio.clip = bgMusic;
        gameAudio.Play();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }

    void Update()
    {
        if (playerControllerScript.gameOver == true)
        {
            gameAudio.Stop();
        }
    }
}
