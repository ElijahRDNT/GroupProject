using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackward : MonoBehaviour
{
    public float speed = 5;
    private PlayerController playerControllerScript;
    private SpawnManager spawnManagerScript; // Add

    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        spawnManagerScript = GameObject.Find("Spawn Manager").GetComponent<SpawnManager>(); // Add
        // StartCoroutine(SpeedUpdate());
    }

    // Update is called once per frame
    void Update()
    {
        if (playerControllerScript.gameOver == false)
        {
            // transform.Translate(-Vector3.forward * Time.deltaTime * speed);
            transform.Translate(-Vector3.forward * Time.deltaTime * spawnManagerScript.speed); // Add
        }
        
        if (transform.position.z < -50 && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }

}
