using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryChair : MonoBehaviour
{
    public GameObject inttext;
    public bool interactable;
    public Animator chairAnim;
    public AudioSource childSound;

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
                childSound.Play();
                chairAnim.SetTrigger("Move");
            }
        }
    }
}
