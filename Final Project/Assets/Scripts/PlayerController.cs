using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private Animator playerAnim;
    private GameManager gameManager; // Referencing the Game Manager script
    public float jumpForce;
    public float speed;
    public int life = 1;
    public bool isOnGround = true;
    public bool gameOver = false;
    // Variables needed for sounds
    private AudioSource playerAudio;
    public AudioClip jumpSound;
    public AudioClip bumpSound;
    public AudioClip bump1Sound;
    public AudioClip lifeSound;
    public AudioClip fallSound;
    public AudioClip fall1Sound;
    public AudioClip gameOverSound;
    // Varibale needed for particle effects
    public ParticleSystem lifeParticle;


    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

    }


    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput); // To make the player turn left or right using the right and left arrow key

        if (Input.GetKeyDown(KeyCode.UpArrow) && isOnGround) // To make the player jump when you press the up arrow key
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            playerAnim.SetTrigger("Jump"); // Adding an animation for jumping
            playerAudio.PlayOneShot(jumpSound, 0.5f); // Adding a jump sfx
        }

        if (life == 0) // If the player's life is 0, the game is over
        {
            gameOver = true;
            gameManager.GameOver();
            playerAnim.SetTrigger("Idle"); 
        }

    }

    private void OnCollisionEnter(Collision collision) 
    {
        if (collision.gameObject.CompareTag("Obstacle")) // If the player collides with an obstacle, there will be an impact
        {
            Rigidbody obstacleRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = (transform.position - collision.gameObject.transform.position);
            playerRb.AddForce(awayFromPlayer * 50, ForceMode.Impulse);
            // Adding a sfx when the player collides with an obstacle
            playerAudio.PlayOneShot(bumpSound, 1.0f); 
            playerAudio.PlayOneShot(bump1Sound, 0.6f);
        }

        if (collision.gameObject.CompareTag("Ground") && gameOver == false) // If the player falls, as long as the game is not over, the player will keep going back to the ground and run
        {
            isOnGround = true;
            playerAnim.SetTrigger("Run"); // Adding an animation for running

        } else if (collision.gameObject.CompareTag("Ground") && gameOver == true) // If the player falls and lose all his life, after he went back to the ground, the game is over
        {
            playerAudio.PlayOneShot(gameOverSound, 1.0f); // Adding an sfx for game over
        }

    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Life")) // If the player collides with the burger, he will earn a life
        {
            lifeParticle.Play(); // Adding a particle effects when he earns a life
            life++;
            Destroy(other.gameObject); // Destroying the burger
            playerAudio.PlayOneShot(lifeSound, 1.0f); // Adding a sfx for collecting a life
        }

        if (life > 5) // The maximum life the player could get is 5
        {
            life = 5;
        }

        if (other.CompareTag("Sand") && life > 0) // If the player falls, one life will be deducted and he will return to the ground
        {
            life -= 1;
            transform.position = new Vector3(0.3f, 3, 0);
        }

        if (other.CompareTag("Trigger")) 
        {
            playerAnim.SetTrigger("Fall"); // Adding a falling animation
            // Adding a sfx for falling
            playerAudio.PlayOneShot(fallSound, 1.0f);
            playerAudio.PlayOneShot(fall1Sound, 0.5f);
        }
    }
}
