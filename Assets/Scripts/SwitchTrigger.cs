using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchTrigger : MonoBehaviour
{
    public GameObject scareObject;
    LightSwitchInteraction lightSwitchScript;
    public AudioSource scareSound;
    public bool hasTriggered;

    void Start(){
        lightSwitchScript = GetComponent<LightSwitchInteraction>();
    }

    void Update(){
        if(lightSwitchScript.toggle == true && !hasTriggered){
            scareObject.SetActive(true);
            scareSound.Play();
            hasTriggered = true;
        }
    }

}
