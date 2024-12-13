using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CornerValvePickup : MonoBehaviour
{
    public GameObject inttext, cornerValve, doorBoom;
    public bool interactable;

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            inttext.SetActive(true);
            interactable = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            inttext.SetActive(false);
            interactable = false;
        }
    }
    void Update()
    {
        if (interactable == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                inttext.SetActive(false);
                interactable = false;
                // doorBoom.SetActive(true);
                cornerValve.SetActive(false);
            }
        }
    }
}
