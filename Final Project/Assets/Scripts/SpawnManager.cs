using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] obstaclePrefabs;
    private float spawnRangeX = 2;
    private float spawnPosZ = 80;
    public float spawnInterval = 2.5f;
    private PlayerController playerControllerScript; // Referencing the Player Controller script
    public float speed;


    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }


    void Update()
    {

    }

    public IEnumerator SpawnRandomObstacles() // For spawning random obstacles in the game
    {
        while (playerControllerScript.gameOver == false)
        {
            yield return new WaitForSeconds(spawnInterval);
            int obstacleIndex = Random.Range(0, obstaclePrefabs.Length);
            Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);
            Instantiate(obstaclePrefabs[obstacleIndex], spawnPos, obstaclePrefabs[obstacleIndex].transform.rotation);
        }
        
    }

    public IEnumerator SpeedUpdate() // For updating the pace of the game and the spawn interval of each obstacles
    {
        while (playerControllerScript.gameOver == false)
        {
            yield return new WaitForSeconds(10);
            speed += 3;
            spawnInterval /= 1.1f;
        }
    }
}
