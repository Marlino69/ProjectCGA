using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isLocked : MonoBehaviour
{
    public GameObject key;
    public bool locked;

    void Update(){
        if(key.activeInHierarchy == true){
            locked = true;
        }
        if(key.activeInHierarchy == false){
            locked = false;
        }
    }
}
