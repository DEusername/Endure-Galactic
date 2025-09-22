using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wifeShipMovement : MonoBehaviour
{
    public Animator animator;

    public GameObject playerHuman;
    public GameObject rejectDialogue;
    public GameObject acceptanceDialogue;
    public GameObject gameOverScreen;
    public GameObject pickedUpPlayerDialogue;

    public float regularMovementSpeed = 1f;
    public float matchDriftMovementSpeed = 0.5f;
    public float stoppingDistance = 6f;

    private bool moveToPlayer = true;
    private bool moveParallelPlayer = false;
    private bool rejectOccured = false;
    private bool rejectJustHappened = true;
    private bool wedOptionPicked = false;

    private void Start()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);
    }

    // Update is called once per frame
    void Update()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, playerHuman.transform.position);
        if (moveToPlayer)
        {
            // Rotate the object's transform to face the base object
            Vector3 directionToBase = playerHuman.transform.position - transform.position;
            Quaternion rotation = Quaternion.LookRotation(directionToBase, Vector3.forward);
            transform.rotation = rotation;

            if (distanceToPlayer >= stoppingDistance)
            {
                // Move the object forward based on its local forward direction
                transform.Translate(Vector3.up * regularMovementSpeed * Time.deltaTime);
            }
            else
            {
                moveToPlayer = false;
                moveParallelPlayer = true;
            }
        }

        if(moveParallelPlayer)
        {
            transform.Translate(Vector3.up * matchDriftMovementSpeed * Time.deltaTime, Space.World);
        }

        if (acceptanceDialogue.activeSelf == true)
        {
            wedOptionPicked = true;
        }

        if(rejectDialogue.activeSelf == true)
        {
            rejectOccured = true;
        }

        if (rejectOccured && rejectDialogue.activeSelf == false)
        {
            if (rejectJustHappened)
            {
                // turn the wifeShip 180 degrees
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z + 180f);

                StartCoroutine(GameOverTime(13));

                rejectJustHappened = false;
            }

            // Move the object forward based on its local forward direction
            transform.Translate(Vector3.up * regularMovementSpeed * Time.deltaTime);
        }

        if (wedOptionPicked == true && acceptanceDialogue.activeSelf == false)
        {
            moveToPlayer = true;
            moveParallelPlayer = false;
            stoppingDistance = 0.1f;
            wedOptionPicked = false;
        }
        else
        {
            if(distanceToPlayer <= 0.3f)
            {
                playerHuman.SetActive(false);
                pickedUpPlayerDialogue.SetActive(true);
            }
        }
    }

    IEnumerator GameOverTime(int timeWait)
    {
        yield return new WaitForSeconds(timeWait);
        gameOverScreen.SetActive(true);
        animator.speed = 1f;
        animator.SetTrigger("GameOverFadeOut");
    }
}
