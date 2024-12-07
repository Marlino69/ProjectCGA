using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonJumpscare : MonoBehaviour
{
    public GameObject ghost, block1, block2;
    public Collider collision;
    public bool blocks;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ghost.SetActive(true);
            if(blocks == true)
            {
                block1.SetActive(true);
                block2.SetActive(true);
            }
            collision.enabled = false;
        }
    }
}