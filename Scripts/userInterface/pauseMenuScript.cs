using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseMenuScript : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public OrientToMouse playerRotationScript;
    public createBullet bulletFireScript;
    public cameraZoom cameraZoomScript;

    private bool isPaused = false;
    public bool diffMenuScreen = false;

    private void Update()
    {
        if(!diffMenuScreen)
        {
            // Check for "Escape" key press to toggle pause menu
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (isPaused)
                    Resume();
                else
                    Pause();
            }
        }


        // Check if the component is active (enabled)
        //if (someComponent.enabled)
        //{
        //    Debug.Log("The component is active.");
        //}
        //else
        //{
        //    Debug.Log("The component is not active.");
        //}
    }

    public void Pause()
    {
        // Activate the pause menu UI
        pauseMenuUI.SetActive(true);

        // Freeze time and disable player interaction (optional)
        Time.timeScale = 0f;

        playerRotationScript.stopRotate();
        bulletFireScript.stopShoot();
        cameraZoomScript.notOkToZoom();

        isPaused = true;
    }

    public void Resume()
    {
        // Deactivate the pause menu UI
        pauseMenuUI.SetActive(false);

        // Unfreeze time and enable player interaction (optional)
        Time.timeScale = 1f;

        playerRotationScript.startRotate();
        bulletFireScript.startShoot();
        cameraZoomScript.okToZoom();

        isPaused = false;
    }

    public void setTrueDiffMenuScreen()
    {
        diffMenuScreen = true;
    }

    public void setFalseDiffMenuScreen()
    {
        diffMenuScreen = false;
    }
}
