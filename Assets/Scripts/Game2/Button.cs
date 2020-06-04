using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    [SerializeField] Block block;

    // Start is called before the first frame update
    void Start()
    {
        if (block == null)
        {
            Debug.LogError("Block is not set!");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        block.gameObject.SetActive(false);
    }
}
