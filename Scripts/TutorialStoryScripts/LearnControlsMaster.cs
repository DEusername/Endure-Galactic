using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LearnControlsMaster : MonoBehaviour
{
    public Animator animator;

    public scene2WifeMaster scene2MasterScript;
    public healthSystem playerHealthSystemScript;

    public GameObject pickedUpPlayerDialogue;
    public GameObject humanPlayer;
    public GameObject player;
    public GameObject wifeShip;
    public GameObject gameCamera;
    public GameObject hud;
    public GameObject activeGameScene1Stuff;
    public GameObject gameOverCanvas;

    public GameObject regEnemyPrefab;
    public GameObject carrierOrbitPrefab;
    public GameObject sniperEnemy;
    public GameObject mineDropperEnemy;
    public GameObject galleonEnemy;


    private GameObject controlsDialogue1;
    private GameObject controlsDialogueEnemyKill;
    private GameObject controlsDialogueGroupKill;
    private GameObject controlsDialogueClusterKill;
    private GameObject controlsDialogueExitTutorial;
    private GameObject tutorialFinishCanvas;

    private GameObject missileLauncherRight;
    private GameObject missileLauncherLeft;
    private GameObject turretRight;
    private GameObject turretLeft;

    private musicBoxMaster musicBox;
    private AudioSource camAudio;

    private bool firstTimeInBeginControlTut = true;
    private bool beginControlTutorial = false;

    private bool controlsDialogue1Active = false;
    private bool D1EnemyJustSpawned = false;

    private bool spawnGroupEnemy = false;
    private bool activateKillGroupDialogue = false;
    private bool spawnClusterEnemy = false;

    private bool activateKillClusterDialogue = false;
    private bool spawnGalleonEnemy = false;
    private bool activateExitTutorialDialogue = false;
    private bool lastDialogueActive = false;

    private bool playerStillAlive = true;


    private void Start()
    {
        controlsDialogue1 = activeGameScene1Stuff.transform.Find("ControlsDialogueCanvas").gameObject;
        controlsDialogueEnemyKill = activeGameScene1Stuff.transform.Find("ControlsDialogueEnemyKilled").gameObject;
        controlsDialogueGroupKill = activeGameScene1Stuff.transform.Find("ControlsDialogueGroupKilled").gameObject;
        controlsDialogueClusterKill = activeGameScene1Stuff.transform.Find("ControlsDialogueClusterKilled").gameObject;
        controlsDialogueExitTutorial = activeGameScene1Stuff.transform.Find("EndTutorialDialogue").gameObject;

        tutorialFinishCanvas = activeGameScene1Stuff.transform.Find("TutorialEndFadeCanvas").gameObject;

        missileLauncherRight = player.transform.Find("MissileSpawnRight").gameObject;
        missileLauncherLeft = player.transform.Find("MissileSpawnLeft").gameObject;
        turretRight = player.transform.Find("TurretRight").gameObject;
        turretLeft = player.transform.Find("TurretLeft").gameObject;

        musicBox = gameCamera.GetComponent<musicBoxMaster>();
        camAudio = gameCamera.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (firstTimeInBeginControlTut && scene2MasterScript.GetWifeSpawnedInYet() == true && humanPlayer.activeSelf == false &&
            pickedUpPlayerDialogue.activeSelf == false)
        {
            beginControlTutorial = true;
        }

        if(beginControlTutorial)
        {
            player.SetActive(true);
            playerStillAlive = true;
            player.transform.position = wifeShip.transform.position;
            wifeShip.SetActive(false);
            Time.timeScale = 1;
            beginControlTutorial = false;
            firstTimeInBeginControlTut = false;
            DisableCameraFollowAnything();
            EnableCameraZoom();
            EnableCameraFollowPlayer();
            setHealthActive();
            setScrapActive();
            controlsDialogue1.SetActive(true);
            controlsDialogue1Active = true;
        }

        if(playerStillAlive && controlsDialogue1Active && controlsDialogue1.activeSelf == false)
        {
            if(camAudio.clip.name != "CombatTheme1")
            {
                musicBox.PlayMusicTrack2();
            }
            carrierSpawnDir2(25);
            controlsDialogue1Active = false;
            D1EnemyJustSpawned = true;
        }

        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        if (playerStillAlive && D1EnemyJustSpawned && enemies.Length == 0)
        {
            controlsDialogueEnemyKill.SetActive(true);
            D1EnemyJustSpawned = false;
            spawnGroupEnemy = true;
        }
        
        if(playerStillAlive && spawnGroupEnemy && controlsDialogueEnemyKill.activeSelf == false)
        {
            carrierSpawnDir1(25);
            mineDropperSpawnDir1(27);
            spawnGroupEnemy = false;
            activateKillGroupDialogue = true;
        }

        enemies = GameObject.FindGameObjectsWithTag("Enemy");

        if(playerStillAlive && activateKillGroupDialogue && enemies.Length == 0)
        {
            missileLauncherRight.SetActive(true);
            missileLauncherLeft.SetActive(true);

            controlsDialogueGroupKill.SetActive(true);
            activateKillGroupDialogue = false;
            spawnClusterEnemy = true;
        }

        if(playerStillAlive && spawnClusterEnemy && controlsDialogueGroupKill.activeSelf == false)
        {
            carrierSpawnDir3(30);
            mineDropperSpawnDir1(30);
            sniperSpawnDir1(25);
            spawnClusterEnemy = false;
            activateKillClusterDialogue = true;
        }

        enemies = GameObject.FindGameObjectsWithTag("Enemy");

        if (playerStillAlive && activateKillClusterDialogue && enemies.Length == 0)
        {
            turretLeft.SetActive(true);
            turretRight.SetActive(true);

            controlsDialogueClusterKill.SetActive(true);
            activateKillClusterDialogue = false;
            spawnGalleonEnemy = true;
        }

        if (playerStillAlive && spawnGalleonEnemy && controlsDialogueClusterKill.activeSelf == false)
        {
            galleonSpawnDir2(35);
            spawnGalleonEnemy = false;
            activateExitTutorialDialogue = true;
        }

        enemies = GameObject.FindGameObjectsWithTag("Enemy");

        if (playerStillAlive && activateExitTutorialDialogue && enemies.Length == 0)
        {
            controlsDialogueExitTutorial.SetActive(true);
            activateExitTutorialDialogue = false;
            lastDialogueActive = true;
        }

        if (playerStillAlive && lastDialogueActive && controlsDialogueExitTutorial.activeSelf == false)
        {
            tutorialFinishCanvas.SetActive(true);
            animator.SetTrigger("TutEndFadeOut");
            lastDialogueActive = false;
        }

        int notMineCounter = 0;
        foreach (GameObject enemy in enemies)
        {
            if (enemy.name != "Mine(Clone)" && enemy.name != "MovingMine(Clone)")
            {
                Debug.Log("exists an object in enemies array that is not named Mine or MovingMine");
                notMineCounter++;
            }
        }
        if (notMineCounter == 0 && enemies.Length > 0)
        {
            Debug.Log("There exists only mines left on the field");
            foreach (GameObject enemy in enemies)
            {
                Destroy(enemy);
            }
        }

        if (player.activeSelf == false)
        {
            foreach (GameObject enemy in enemies)
            {
                Destroy(enemy);
            }
            playerStillAlive = false;
        }
    }

    // restart methods to restart tutorial from the first control dialogue box by resetting any changed variables to initial state

    public void RestartGame()
    {
        StartCoroutine(FadeOutTheGameOverScreen());
    }

    IEnumerator FadeOutTheGameOverScreen()
    {
        animator.SetTrigger("GameOverRestartOccur");
        yield return new WaitForSeconds(2);
        RestartFightSequence();
    }

    public void RestartFightSequence()
    {
        gameOverCanvas.SetActive(false);

        firstTimeInBeginControlTut = true;
        beginControlTutorial = false;

        controlsDialogue1Active = false;
        D1EnemyJustSpawned = false;

        spawnGroupEnemy = false;
        activateKillGroupDialogue = false;
        spawnClusterEnemy = false;

        activateKillClusterDialogue = false;

        playerHealthSystemScript.setCurrentHealth(100);
    }


    // ENEMY  SPAWN  METHODS

    // regular enemy spawn methods in 4 different directions
    private void regEnemySpawnDir1(int distanceFromPlayer)
    {
        Vector3 targetPosition = player.transform.position + (player.transform.up + -player.transform.right).normalized * distanceFromPlayer;
        GameObject regEnemy = Instantiate(regEnemyPrefab, targetPosition, Quaternion.identity);
    }

    private void regEnemySpawnDir2(int distanceFromPlayer)
    {
        Vector3 targetPosition = player.transform.position + (-player.transform.up + -player.transform.right).normalized * distanceFromPlayer;
        GameObject regEnemy = Instantiate(regEnemyPrefab, targetPosition, Quaternion.identity);
    }

    private void regEnemySpawnDir3(int distanceFromPlayer)
    {
        Vector3 targetPosition = player.transform.position + (player.transform.up + player.transform.right).normalized * distanceFromPlayer;
        GameObject regEnemy = Instantiate(regEnemyPrefab, targetPosition, Quaternion.identity);
    }

    private void regEnemySpawnDir4(int distanceFromPlayer)
    {
        Vector3 targetPosition = player.transform.position + (-player.transform.up + player.transform.right).normalized * distanceFromPlayer;
        GameObject regEnemy = Instantiate(regEnemyPrefab, targetPosition, Quaternion.identity);
    }


    // carrier spawn in 4 different directions 
    private void carrierSpawnDir1(int distanceFromPlayer)
    {
        Vector3 targetPosition = player.transform.position + (player.transform.up + player.transform.right).normalized * distanceFromPlayer;
        GameObject carrierEnemy = Instantiate(carrierOrbitPrefab, targetPosition, Quaternion.identity);
    }

    private void carrierSpawnDir2(int distanceFromPlayer)
    {
        Vector3 targetPosition = player.transform.position + (-player.transform.up + player.transform.right).normalized * distanceFromPlayer;
        GameObject carrierEnemy = Instantiate(carrierOrbitPrefab, targetPosition, Quaternion.identity);
    }

    private void carrierSpawnDir3(int distanceFromPlayer)
    {
        Vector3 targetPosition = player.transform.position + (player.transform.up + -player.transform.right).normalized * distanceFromPlayer;
        GameObject carrierEnemy = Instantiate(carrierOrbitPrefab, targetPosition, Quaternion.identity);
    }

    private void carrierSpawnDir4(int distanceFromPlayer)
    {
        Vector3 targetPosition = player.transform.position + (-player.transform.up + -player.transform.right).normalized * distanceFromPlayer;
        GameObject carrierEnemy = Instantiate(carrierOrbitPrefab, targetPosition, Quaternion.identity);
    }

    // sniper ship spawn in 2 directions

    private void sniperSpawnDir1(int distanceFromPlayer)
    {
        Vector3 targetPosition = player.transform.position + (player.transform.up + player.transform.right).normalized * distanceFromPlayer;
        GameObject carrierEnemy = Instantiate(sniperEnemy, targetPosition, Quaternion.identity);
    }

    private void sniperSpawnDir2(int distanceFromPlayer)
    {
        Vector3 targetPosition = player.transform.position + (-player.transform.up + -player.transform.right).normalized * distanceFromPlayer;
        GameObject carrierEnemy = Instantiate(sniperEnemy, targetPosition, Quaternion.identity);
    }

    // mine dropper spawn in 2 directions

    private void mineDropperSpawnDir1(int distanceFromPlayer)
    {
        Vector3 targetPosition = player.transform.position + (player.transform.up + player.transform.right).normalized * distanceFromPlayer;
        GameObject carrierEnemy = Instantiate(mineDropperEnemy, targetPosition, Quaternion.identity);
    }

    private void mineDropperSpawnDir2(int distanceFromPlayer)
    {
        Vector3 targetPosition = player.transform.position + (-player.transform.up + -player.transform.right).normalized * distanceFromPlayer;
        GameObject carrierEnemy = Instantiate(mineDropperEnemy, targetPosition, Quaternion.identity);
    }

    // Galleon boss spawn in 2 directions

    private void galleonSpawnDir1(int distanceFromPlayer)
    {
        Vector3 targetPosition = player.transform.position + (player.transform.up + player.transform.right).normalized * distanceFromPlayer;
        GameObject carrierEnemy = Instantiate(galleonEnemy, targetPosition, Quaternion.identity);
    }

    private void galleonSpawnDir2(int distanceFromPlayer)
    {
        Vector3 targetPosition = player.transform.position + (-player.transform.up + -player.transform.right).normalized * distanceFromPlayer;
        GameObject carrierEnemy = Instantiate(galleonEnemy, targetPosition, Quaternion.identity);
    }


    // END  ENEMY  SPAWN  METHODS




    // set the hud elements to be active
    public void setHealthActive()
    {
        GameObject healthInHud = hud.transform.Find("UiHealth").gameObject;

        healthInHud.SetActive(true);

        GameObject healthBackground = hud.transform.Find("HealthBackground").gameObject;

        healthBackground.SetActive(true);
    }

    public void setScrapActive()
    {
        GameObject scrapInHud = hud.transform.Find("UiScrap").gameObject;

        scrapInHud.SetActive(true);

        GameObject scrapBackground = hud.transform.Find("ScrapBackground").gameObject;

        scrapBackground.SetActive(true);
    }



    // reset camera to follow the actual playable character
    public void EnableCameraZoom()
    {
        cameraZoom script = gameCamera.GetComponent<cameraZoom>();
        if (script != null)
        {
            script.enabled = true; // Enable the script
        }
    }

    public void EnableCameraFollowPlayer()
    {
        ShipCamera script = gameCamera.GetComponent<ShipCamera>();
        if (script != null)
        {
            script.enabled = true; // Enable the script
        }
    }

    public void DisableCameraFollowAnything()
    {
        CameraFollowAnything script = gameCamera.GetComponent<CameraFollowAnything>();
        if (script != null)
        {
            script.enabled = false; // disable the script
        }
    }
}
