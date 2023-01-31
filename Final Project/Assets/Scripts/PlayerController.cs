using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private Animator playerAnim;
    public float jumpForce;
    public float speed;
    public int life = 1;
    public bool isOnGround = true;
    public bool gameOver = false;


    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();

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
        }

        if (life == 0)
        {
            gameOver = true;
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
        }

        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            playerAnim.SetTrigger("Run");

        }


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Life"))
        {
            life++;
            Destroy(other.gameObject);
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
        }

    }
}
