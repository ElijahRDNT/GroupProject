using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatPlane : MonoBehaviour
{
    private Vector3 startPos;
    private float repeatWidth;


    void Start()
    {
        startPos = transform.position;
        repeatWidth = GetComponent<BoxCollider>().size.z / 10;
    }


    void Update()
    {
        // Making the plane repeat
        if (transform.position.z < startPos.z - repeatWidth)
        {
            transform.position = startPos;
        }
    }
}
