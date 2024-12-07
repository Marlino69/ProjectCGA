using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject loadingScreen, menuObj, settingObj;
    public string sceneName;


    void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
    public void playGame()
    {
        loadingScreen.SetActive(true);
        StartCoroutine(LoadSceneAfterDelay());
    }

    private IEnumerator LoadSceneAfterDelay()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(sceneName);
    }

    public void SettingsMenu()
    {
        menuObj.SetActive(false);
        settingObj.SetActive(true); 
    }

    public void quitGame()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }

    public void backToMenu()
    {
        settingObj.SetActive(false);
        menuObj.SetActive(true);
    }

}
