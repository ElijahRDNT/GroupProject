using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] obstaclePrefabs;
    private float spawnRangeX = 2;
    private float spawnPosZ = 80;
    public float spawnInterval = 2.5f; // Change
    // private float startDelay = 2;
    private PlayerController playerControllerScript;
    public float speed; // Add

    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        StartCoroutine(SpeedUpdate()); // Add
        // InvokeRepeating("SpawnRandomObstacles", startDelay, spawnInterval);
        StartCoroutine(SpawnRandomObstacles()); // Add
    }

    // Update is called once per frame
    void Update()
    {

    }

    // void SpawnRandomObstacles()
    // {
        // int obstacleIndex = Random.Range(0, obstaclePrefabs.Length);
        // Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);
        // if (playerControllerScript.gameOver == false)
        // {
            // Instantiate(obstaclePrefabs[obstacleIndex], spawnPos, obstaclePrefabs[obstacleIndex].transform.rotation);
        // }
    // }

    IEnumerator SpawnRandomObstacles()
    {
        while (playerControllerScript.gameOver == false)
        {
            yield return new WaitForSeconds(spawnInterval);
            int obstacleIndex = Random.Range(0, obstaclePrefabs.Length);
            Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);
            Instantiate(obstaclePrefabs[obstacleIndex], spawnPos, obstaclePrefabs[obstacleIndex].transform.rotation);
        }
        
    }

    IEnumerator SpeedUpdate() // Add
    {
        while (playerControllerScript.gameOver == false)
        {
            yield return new WaitForSeconds(10);
            speed += 3;
            spawnInterval /= 1.1f;
        }
    }
}
