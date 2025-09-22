using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public void EnterIntoTutorialLevel()
    {
        SceneManager.LoadScene("Tutorial");
        Time.timeScale = 1;
    }

    public void EnterIntoSurviveLevel()
    {
        SceneManager.LoadScene("OpenWorld");
        Time.timeScale = 1;
    }

    public void ExitGame()
    {
        Debug.Log("Successful Exit of Game");
        Application.Quit();
    }
}
