using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackward : MonoBehaviour
{
    public float speed = 5;
    private PlayerController playerControllerScript; // Referencing the Player Controller script
    private SpawnManager spawnManagerScript; // Referencing the Spawn Manager script


    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        spawnManagerScript = GameObject.Find("Spawn Manager").GetComponent<SpawnManager>();
    }


    void Update()
    {
        if (playerControllerScript.gameOver == false) // To make an object move backwards
        {
            transform.Translate(-Vector3.forward * Time.deltaTime * spawnManagerScript.speed);
        }
        
        if (transform.position.z < -50 && gameObject.CompareTag("Obstacle")) // Destroying an obstacle if it reach a certain position
        {
            Destroy(gameObject);
        }
    }

}
