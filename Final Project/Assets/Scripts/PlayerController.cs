using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private Animator playerAnim;
    private AudioSource playerAudio;
    public float jumpForce;
    public float speed;
    public int life = 1;
    public bool isOnGround = true;
    public bool gameOver = false;
    public AudioClip jumpSound;
    public AudioClip bumpSound;
    public AudioClip bump1Sound;
    public AudioClip lifeSound;
    public AudioClip fallSound;
    public AudioClip fall1Sound;
    public AudioClip gameOverSound;


    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput);

        if (Input.GetKeyDown(KeyCode.UpArrow) && isOnGround)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            playerAnim.SetTrigger("Jump");
            playerAudio.PlayOneShot(jumpSound, 0.5f);
        }

        if (life == 0)
        {
            gameOver = true;
            playerAnim.SetTrigger("Idle");
            Debug.Log("Game Over");
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Rigidbody obstacleRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = (transform.position - collision.gameObject.transform.position);
            playerRb.AddForce(awayFromPlayer * 20, ForceMode.Impulse);
            playerAudio.PlayOneShot(bumpSound, 1.0f);
            playerAudio.PlayOneShot(bump1Sound, 0.6f);
        }

        if (collision.gameObject.CompareTag("Ground") && gameOver == false)
        {
            isOnGround = true;
            playerAnim.SetTrigger("Run");

        } else if (collision.gameObject.CompareTag("Ground") && gameOver == true)
        {
            playerAudio.PlayOneShot(gameOverSound, 1.0f);
        }


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Life"))
        {
            life++;
            Destroy(other.gameObject);
            playerAudio.PlayOneShot(lifeSound, 1.0f);
        }

        if (life > 5)
        {
            life = 5;
        }

        if (other.CompareTag("Sand") && life > 0)
        {
            life -= 1;
            transform.position = new Vector3(0.3f, 3, 0);
        }

        if (other.CompareTag("Trigger"))
        {
            playerAnim.SetTrigger("Fall");
            playerAudio.PlayOneShot(fallSound, 1.0f);
            playerAudio.PlayOneShot(fall1Sound, 0.5f);
        }

    }
}
