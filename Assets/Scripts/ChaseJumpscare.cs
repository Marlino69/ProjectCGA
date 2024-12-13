using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseJumpscare : MonoBehaviour
{
    public Animator chaseGhostAnim;
    public GameObject player, ghost, block1, block2;
    public float jumpscareTime;
    public AudioSource jumpscareSound, followingSound;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player.SetActive(false);
            chaseGhostAnim.SetTrigger("jumpscare");
            jumpscareSound.Play();
            followingSound.Stop();
            StartCoroutine(jumpscare());
        }
    }
    IEnumerator jumpscare()
    {
        yield return new WaitForSeconds(jumpscareTime);
        jumpscareSound.Stop();
        block1.SetActive(false);
        block2.SetActive(false);
        player.SetActive(true);
        ghost.SetActive(false);
    }
}