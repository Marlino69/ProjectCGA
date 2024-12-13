using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomDoorJumpscare : MonoBehaviour
{
    public DoorLogic door;
    public GameObject valve;
    public AudioSource scareSound;
    public Collider collision;
    public Animator doorAnim;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (valve.activeInHierarchy == false)
            {
                door.toggle = !door.toggle;
                if (door.toggle == true)
                {
                    doorAnim.ResetTrigger("Close");
                    doorAnim.SetTrigger("Open");
                }
                if (door.toggle == false)
                {
                    doorAnim.ResetTrigger("Open");
                    doorAnim.SetTrigger("Boom");
                }
                scareSound.Play();
                collision.enabled = false;
            }

        }
    }
}
