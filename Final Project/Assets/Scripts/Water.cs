using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    [SerializeField] float flowSpeed = 1f;
    [SerializeField] float upDownMoveSpeed = 1f;

    MeshRenderer meshRenderer;


    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }


    void Update()
    {
        // For water to flow and move up and down
        meshRenderer.material.mainTextureOffset = new Vector2(Mathf.Sin(Time.time * flowSpeed), 0f);
        transform.position = new Vector3(transform.position.x, Mathf.Sin(Time.time * upDownMoveSpeed), transform.position.z);
    }
}
