using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartValve : MonoBehaviour
{
   public GameObject inttext, firstValve, cornerValve;
   public bool interactable;
   public Animator valveAnim;


    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            if(cornerValve.activeInHierarchy == false && firstValve.activeInHierarchy == false){
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
        if(interactable == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {

                inttext.SetActive(false);
                interactable = false;
                // firstValve.SetActive(true);
                valveAnim.SetTrigger("insert");
            }
        }
    }
}
