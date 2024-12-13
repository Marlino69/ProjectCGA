using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DollRotate : MonoBehaviour
{
    public GameObject valve;
    public AudioSource scareSound;
    public Collider collision;
    public Animator dollAnim;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (valve.activeInHierarchy == false)
            {
                dollAnim.SetTrigger("Rotate");
                scareSound.Play();
                collision.enabled = false;
            }

        }
    }
}
