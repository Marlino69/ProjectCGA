using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnOffFlashlight : MonoBehaviour
{
    public GameObject lightObject;
    public bool toggle;
    public AudioSource toggleSound;

    void Start()
    {
        if(toggle == false)
        {
            lightObject.SetActive(false);
        }
        if (toggle == true)
        {
            lightObject.SetActive(true);
        }
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            toggle = !toggle;
            //toggleSound.Play();
            if(toggle == false)
            {
                lightObject.SetActive(false);
            }
            if (toggle == true)
            {
                lightObject.SetActive(true);
            }
        }
    }
}
