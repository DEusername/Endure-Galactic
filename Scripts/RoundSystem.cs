using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundSystem : MonoBehaviour
{
    public GameObject player;

    public GameObject introDialogue;

    public GameObject regEnemyPrefab;
    public GameObject carrierOrbitPrefab;
    public GameObject sniperEnemy;
    public GameObject mineDropperEnemy;
    public GameObject galleonEnemy;
    public GameObject golliathEnemy;

    private bool dialogueGoneAway = false;

    private int roundNum = 0;

    
    // Update is called once per frame
    void Update()
    {
        if (!dialogueGoneAway && introDialogue.activeSelf == false)
        {
            dialogueGoneAway = true;
        }

        if(dialogueGoneAway)
        {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

            int notMineCounter = 0;
            foreach (GameObject enemy in enemies)
            {
                if (enemy.name != "Mine(Clone)" && enemy.name != "MovingMine(Clone)")
                {
                    notMineCounter++;
                }
            }
            if (notMineCounter == 0 && enemies.Length > 0)
            {
                foreach (GameObject enemy in enemies)
                {
                    Destroy(enemy);
                }
            }

            if (enemies.Length == 0)
            {
                StartCoroutine(newRound(++roundNum));
            }
        }
    }

    IEnumerator newRound(int roundNum)
    {
        while(roundNum > 0)
        {
            if(roundNum % 10 == 0)
            {
                golliathSpawnDir2(30);
                break;
            }

            int switchPluginNum = roundNum % 5;
            roundNum -= 5;
            Debug.Log(roundNum);

            switch (switchPluginNum)
            {
                // the cases are meant to fall through
                case 0:
                    galleonSpawnDir2(30);
                    goto case 4;

                case 4:
                    sniperSpawnDir2(30);
                    goto case 3;

                case 3:
                    mineDropperSpawnDir1(30);
                    goto case 2;

                case 2:
                    carrierSpawnDir2(30);
                    goto case 1;

                case 1:
                    regEnemySpawnDir1(30);
                    regEnemySpawnDir2(30);
                    regEnemySpawnDir3(30);
                    regEnemySpawnDir4(30);
                    break;

                default:
                    Debug.Log("entered into the default of the round system switch statement");
                    break;
            }

            yield return new WaitForSeconds(2);
        }
    }

    public int getCurrentRound()
    {
        return roundNum;
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

    // Golliath boss spawn in 2 directions

    private void golliathSpawnDir1(int distanceFromPlayer)
    {
        Vector3 targetPosition = player.transform.position + (player.transform.up + player.transform.right).normalized * distanceFromPlayer;
        GameObject carrierEnemy = Instantiate(golliathEnemy, targetPosition, Quaternion.identity);
    }

    private void golliathSpawnDir2(int distanceFromPlayer)
    {
        Vector3 targetPosition = player.transform.position + (-player.transform.up + -player.transform.right).normalized * distanceFromPlayer;
        GameObject carrierEnemy = Instantiate(golliathEnemy, targetPosition, Quaternion.identity);
    }


    // END  ENEMY  SPAWN  METHODS
}
