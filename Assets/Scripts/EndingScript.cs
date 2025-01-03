using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class EndingScript : MonoBehaviour
{
    public GameObject inttext, player, cutsceneCamera;
    public bool interactable;
    public Animator doorAnim;
    public string sceneName;
    public int cutsceneTime;
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
        if (interactable == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                inttext.SetActive(false);
                interactable = false;
                doorAnim.SetTrigger("Open");
                player.SetActive(false);
                cutsceneCamera.SetActive(true);

                StartCoroutine(LoadScene());
            }
        }
    }
    IEnumerator LoadScene()
    {
        yield return new WaitForSeconds(cutsceneTime);
        SceneManager.LoadScene(sceneName);
    }
}
