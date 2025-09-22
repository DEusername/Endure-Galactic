using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scene1EjectMaster : MonoBehaviour
{
    public Animator animator;

    public openingFades openingFadesSystem;
    public GameObject movementDialogue;
    public GameObject ejectDialogue;
    public GameObject prisonerShip;
    public GameObject humanPlayer;
    public GameObject halfFadeCanvas;
    public GameObject openingExcerpt;

    public float prisonShipMovementSpeed = 5f;


    private bool movementDialogueActivated = false;
    private bool movementDialogueCompleted = false;

    private bool ejectDialogueCompleted = false;
    private bool ejectDialogueActivated = false;
    private bool shipLeave = false;
    private bool firstTimeInShipLeave = true;
    private bool haveNotDimmed = true;

    private bool wifeAppearStart = false;

    void Update()
    {

        //first movement part dialogue partition
        if(true)
        {
            //moves deeper if the ships movement speed is above 0 and if the movement dialogue has not been completed.
            //else it sets movement dialogue completed to be true;
            if (prisonShipMovementSpeed >= 0f && movementDialogueCompleted == false)
            {
                //move ship upwards
                prisonerShip.transform.Translate(transform.up * prisonShipMovementSpeed * Time.deltaTime);
            }
            else
            {
                movementDialogueCompleted = true;
            }

            //moves deeper if movement dialogue has not been completed
            if (movementDialogueCompleted == false)
            {
                //moves deeper if opening excerpt is over
                if (openingFadesSystem.GetOpeningExcerptOver() == true && movementDialogueActivated == false)
                {
                    //set the movement dialogue to be active
                    movementDialogue.SetActive(true);
                    movementDialogueActivated = true;
                }
            }

            //move deeper if  movement dialogue is inactive (should slow down the movement of the ship until it slows down)
            if (prisonShipMovementSpeed >= 0 && movementDialogueActivated && movementDialogue.activeSelf == false)
            {
                prisonShipMovementSpeed -= 0.005f;
            }
        }



        //second ejection part dialogue partition
        if (true)
        {
            //moves deeper if eject dialogue has not been activated
            if (ejectDialogueActivated == false)
            {
                //moves deeper if movement dialogue has been completed
                if (movementDialogueCompleted == true)
                {
                    //set the movement dialogue to be active
                    ejectDialogue.SetActive(true);
                    ejectDialogueActivated = true;
                }
            }

            //moves deeper if eject dialogue not over and has been already activated
            if (ejectDialogueCompleted == false && ejectDialogueActivated == true)
            {
                //moves deeper if eject dialogue game object is inactive in scene
                if(ejectDialogue.activeSelf == false)
                {
                    ejectDialogueCompleted = true;
                    StartCoroutine(solemnSilenceAndEject(5));
                }
            }

            if (shipLeave)
            {
                if(firstTimeInShipLeave)
                {
                    // Assuming "targetObject" is the GameObject you want to rotate
                    Vector3 currentRotation = prisonerShip.transform.eulerAngles;
                    Vector3 newRotation = new Vector3(currentRotation.x, currentRotation.y, currentRotation.z + 180f);
                    prisonerShip.transform.eulerAngles = newRotation;
                    firstTimeInShipLeave = false;
                }
                else
                {
                    prisonerShip.transform.Translate(Vector3.up * 1 * Time.deltaTime);
                    StartCoroutine(TurnOffPrisonShipAfterTime(8));
                }

                if(haveNotDimmed)
                {
                    StartCoroutine(HalfFadeOut(8));
                    haveNotDimmed = false;
                }
            }
        }
    }

    //getter for starting scene 2 script
    public bool GetWifeAppearStart()
    {
        return wifeAppearStart;
    }


    //CHUNK
    //eject the player
    IEnumerator solemnSilenceAndEject(int timeWait)
    {
        yield return new WaitForSeconds(timeWait);
        humanPlayer.SetActive(true);
        humanPlayer.transform.position = prisonerShip.transform.position;
        StartCoroutine(LetFloatBeforeLeave(4));
    }

    //let player float for timeWait and then initiate ship leave time
    IEnumerator LetFloatBeforeLeave(int timeWait)
    {
        yield return new WaitForSeconds(timeWait);
        shipLeave = true;
    }
    //END CHUNK

    //CHUNK
    //turns off the prison ship after timeWait time
    IEnumerator TurnOffPrisonShipAfterTime(int timeWait)
    {
        yield return new WaitForSeconds(timeWait);
        prisonerShip.SetActive(false);
        shipLeave = false;
    }
    //END CHUNK

    //CHUNK
    //fades out the scene after timeWait time
    IEnumerator HalfFadeOut(int timeWait)
    {
        yield return new WaitForSeconds(timeWait);
        halfFadeCanvas.SetActive(true);
        animator.SetTrigger("PlayerAdriftFadeOut");
        openingExcerpt.SetActive(false);
        StartCoroutine(HalfFadeIn(12));
    }

    //fades in the scene after timeWait time
    IEnumerator HalfFadeIn(int timeWait)
    {
        yield return new WaitForSeconds(timeWait);
        animator.SetTrigger("PlayerAdriftFadeIn");
        StartCoroutine(DriftAfterFadeIn(8));
    }

    //drifts for some extra time imediately after the fade in starts
    IEnumerator DriftAfterFadeIn(int timeWait)
    {
        yield return new WaitForSeconds(timeWait);
        halfFadeCanvas.SetActive(false);
        wifeAppearStart = true;
    }
}
