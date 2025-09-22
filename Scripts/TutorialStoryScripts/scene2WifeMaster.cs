using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scene2WifeMaster : MonoBehaviour
{
    public Animator animator;

    public scene1EjectMaster scene1MasterScript;
    public GameObject wifeArriveDialogue;
    public GameObject humanPlayer;
    public GameObject wifeShip;
    public GameObject halfFadeCanvas;
    public GameObject wedOrNotButtonsCanvas;

    private float distanceFromPlayer = 12f; // Desired distance from the base object
    private Vector3 targetPosition;

    private bool wifeArriveDialogueCompleted = false;
    private bool wifeSpawnedInYet = false;
    private bool wifeArrivedAtPlayer = false;
    private bool wifeDialogueActivated = false;
    private bool wedOrNotButtonsActivated = false;


    void Update()
    {
        //first wife arrive part dialogue partition
        if (true)
        {
            //moves deeper if the wife arrive dialogue has not been completed and also if the scene 1 get wife appear starting flag has been turned true
            if (!wifeArriveDialogueCompleted && scene1MasterScript.GetWifeAppearStart())
            {
                //move deeper if wife has not been spawned in yet
                if (!wifeSpawnedInYet)
                {
                    wifeShip.SetActive(true);

                    // Calculate the target position based on the desired distance and direction
                    targetPosition = humanPlayer.transform.position + (humanPlayer.transform.up + humanPlayer.transform.right).normalized * distanceFromPlayer;
                    wifeShip.transform.position = targetPosition;

                    wifeSpawnedInYet = true;
                    StartCoroutine(WaitForWifeArrive(6));
                }

                if(!wifeDialogueActivated && wifeArrivedAtPlayer)
                {
                    wifeArriveDialogue.SetActive(true);
                    wifeDialogueActivated = true;
                }

                if (wedOrNotButtonsActivated == false && wifeArriveDialogue.activeSelf == false && wifeDialogueActivated)
                {
                    wedOrNotButtonsCanvas.SetActive(true);
                    wedOrNotButtonsActivated = true;
                }
            }
        }
    }

    public bool GetWifeSpawnedInYet()
    {
        return wifeSpawnedInYet;
    }



    // first wife arrive part coroutines
    IEnumerator WaitForWifeArrive(int timeWait)
    {
        yield return new WaitForSeconds(timeWait);
        wifeArrivedAtPlayer = true;
    }
}
