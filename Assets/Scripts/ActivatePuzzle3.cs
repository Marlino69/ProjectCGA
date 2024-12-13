using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatePuzzle : MonoBehaviour
{
    public GameObject inttext, battery1, battery2, battery3, battery4, battery5;
    public Collider socket1, socket2, socket3, socket4, socket5;
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
                socket1.enabled = true;
                socket2.enabled = true;
                socket3.enabled = true;
                socket4.enabled = true;
                socket5.enabled = true;
                battery1.SetActive(true);
                battery2.SetActive(true);
                battery3.SetActive(true);
                battery4.SetActive(true);
                battery5.SetActive(true);
            }
        }
    }



}
