using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitchInteraction: MonoBehaviour
{
    public GameObject inttext, lightObject;
    public bool toggle = true, interactable;
    public Renderer lightBulb;
    public Material offlight, onlight;
    public AudioSource lightSwitchSound;
    public Animator switchAnim;

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
        if(interactable == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                toggle = !toggle;
                //lightSwitchSound.Play();
                switchAnim.ResetTrigger("Press");
                switchAnim.SetTrigger("Press");
            }
        }
        if(toggle == false)
        {
            lightObject.SetActive(false);
            lightBulb.material = offlight;
        }
        if (toggle == true)
        {
            lightObject.SetActive(true);
            lightBulb.material = onlight;
        }
    }
}