using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartCutscene : MonoBehaviour
{
    public GameObject cutsceneCamera, player;
    public float cutsceneTime;

    void Start(){
        StartCoroutine(cutscene());
    }
    IEnumerator cutscene(){
        yield return new WaitForSeconds(cutsceneTime);
        player.SetActive(true);
        cutsceneCamera.SetActive(false);
    }
}
