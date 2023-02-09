using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeSystem : MonoBehaviour
{
    public GameObject[] burgers;
    private PlayerController playerControllerScript; // Referencing the Player Controller script


    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    void Update()
    {
        // Making an object be seen in the game scene
        if (playerControllerScript.life == 2)
        {
            burgers[1].gameObject.SetActive(true);
        }

        if (playerControllerScript.life == 3)
        {
            burgers[2].gameObject.SetActive(true);
        }

        if (playerControllerScript.life == 4)
        {
            burgers[3].gameObject.SetActive(true);
        }

        if (playerControllerScript.life == 5)
        {
            burgers[4].gameObject.SetActive(true);
        }

        // Making an disappear in the game scene
        if (playerControllerScript.life < 5)
        {
            burgers[4].gameObject.SetActive(false);
        }

        if (playerControllerScript.life < 4)
        {
            burgers[3].gameObject.SetActive(false);
        }

        if (playerControllerScript.life < 3)
        {
            burgers[2].gameObject.SetActive(false);
        }

        if (playerControllerScript.life < 2)
        {
            burgers[1].gameObject.SetActive(false);
        }

        if (playerControllerScript.life < 1)
        {
            burgers[0].gameObject.SetActive(false);
        }
    }

}
