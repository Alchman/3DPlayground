﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{

    MeshRenderer rend;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<MeshRenderer>();
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            MeshRenderer ballRenderer = collision.gameObject.GetComponent<MeshRenderer>();
            Material ballMaterial = ballRenderer.material;
            rend.material.color = ballMaterial.color;

            BallMovement ball = collision.gameObject.GetComponent<BallMovement>();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            rend.material.color = Color.blue;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            rend.material.color = Color.yellow;
        }
    }
}
