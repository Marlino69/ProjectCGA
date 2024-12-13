using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CornerRoomDoor : MonoBehaviour
{
    public GameObject intText, lockedText, firstValve;
    public bool interactable, toggle;
    public Animator doorAnim;

    void Start(){
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
            if(Input.GetKeyDown(KeyCode.E)){
                if(firstValve.activeInHierarchy == false){
                    lockedText.SetActive(true);
                    StopCoroutine("isLockedText");
                    StartCoroutine("isLockedText");
                }
                if(firstValve.activeInHierarchy == true){
                    doorOpenClose();
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
