using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsertBattery : MonoBehaviour
{
    public GameObject inttext, mapBattery, battery;
    public bool interactable, toggle;
    public Collider key;
    public InsertBattery battery1, battery2, battery3, battery4, battery5;
    public Animator fuzeBoxAnim;

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            if (mapBattery.activeInHierarchy == false && battery.activeInHierarchy == false)
            {
                inttext.SetActive(true);
                interactable = true;
            }

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
                toggle = true;
                inttext.SetActive(false);
                interactable = false;
                battery.SetActive(true);
                if (battery1.toggle == true && battery2.toggle == true && battery3.toggle == true && battery4.toggle == true && battery5.toggle == true)
                {
                    key.enabled = true;
                    fuzeBoxAnim.SetTrigger("Open");
                }
            }
        }
    }
}
