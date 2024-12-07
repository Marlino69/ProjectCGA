using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorLogic : MonoBehaviour
{
    public GameObject intText, lockedText;
    public bool interactable, toggle, requireKey = true;
    public Animator doorAnim;
    isLocked keyStatus;

    void Start(){
        keyStatus = GetComponent<isLocked>();
        if(keyStatus == null)
        {
            requireKey = false;
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            intText.SetActive(true);
            interactable = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            intText.SetActive(false);
            interactable = false;
        }
    }
    void Update()
    {
        if(interactable == true)
        {
           
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if(requireKey == false)
                    {
                        doorOpenClose();
                    }
                    if(requireKey == true)
                    {
                        if(keyStatus.locked == false)
                        {
                            doorOpenClose();
                        }
                        if(keyStatus.locked == true)
                        {
                            lockedText.SetActive(true);
                            StopCoroutine("isLockedText");
                            StartCoroutine("isLockedText");
                        }
                    }
                    
                }
            
            
            
        }
    }

    void doorOpenClose(){
        toggle = !toggle;
        if(toggle == true)
        {
            doorAnim.ResetTrigger("Close");
            doorAnim.SetTrigger("Open");
        }
        if (toggle == false)
        {
            doorAnim.ResetTrigger("Open");
            doorAnim.SetTrigger("Close");
        }
        intText.SetActive(false);
        interactable = false;
    }
    IEnumerator isLockedText(){
        yield return new WaitForSeconds(2.0f);
        lockedText.SetActive(false);
    }
}
