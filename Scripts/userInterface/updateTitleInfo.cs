using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class updateTitleInfo : MonoBehaviour
{
    public TextMeshProUGUI highestRoundNumText;
    private int roundAllTimeHighNum;
    public TextMeshProUGUI associatedScrapText;

    public TextMeshProUGUI highestScrapNumText;
    private int scrapAllTimeHighNum;
    public TextMeshProUGUI associatedRoundText;

    private void Awake()
    {
        // loads the old highest round and scrap numbers into the old highest round values.
        int oldHighestRoundNumber = PlayerPrefs.GetInt("OldHighestRoundNumber", 0);
        int oldAssociatedScrap = PlayerPrefs.GetInt("OldAssociatedScrap", 0);

        int oldHighestScrapNumber = PlayerPrefs.GetInt("OldHighestScrapAmount", 0);
        int oldAssociatedRound = PlayerPrefs.GetInt("OldAssociatedRound", 0);

        //initialize the highest round num information on the right
        highestRoundNumText.text = oldHighestRoundNumber.ToString();
        associatedScrapText.text = "Associated Scrap: " + oldAssociatedScrap.ToString();

        //initialize the highest scrap amount information on the left
        highestScrapNumText.text = oldHighestScrapNumber.ToString();
        associatedRoundText.text = "Associated Round: " + oldAssociatedRound.ToString();

        // check new number section

        // grabs the round number and the scrap amounts from the previous game. Returns 0 if there is no saved value here.
        int newRoundNumber = PlayerPrefs.GetInt("RoundNumber", 0);
        int newScrapAmount = PlayerPrefs.GetInt("ScrapAmount", 0);

        // enter if the newRoundNumber > oldHighestRoundNumber
        if (newRoundNumber > oldHighestRoundNumber)
        {
            Debug.Log("enter the first changer");

            // set the highest round number text to the new High Round Number of the last game
            highestRoundNumText.text = newRoundNumber.ToString();

            // set the old highest round number to be equal to the new highest round number
            PlayerPrefs.SetInt("OldHighestRoundNumber", newRoundNumber);

            // associated scrap is changed to the new scrap amount of the last game and so is the player pref old associated scrap
            associatedScrapText.text = "Associated Scrap: " + newScrapAmount.ToString();
            PlayerPrefs.SetInt("OldAssociatedScrap", newScrapAmount);

            PlayerPrefs.Save();
        }

        if (newScrapAmount > oldHighestScrapNumber)
        {
            Debug.Log("enter the second scrap changer");

            // set the highest scrap amount text to the new high scrap number
            highestScrapNumText.text = newScrapAmount.ToString();

            // set the old highest round number to be equal to the new highest round number
            PlayerPrefs.SetInt("OldHighestScrapAmount", newScrapAmount);

            // associated round is changed to the new round amount of the last game and so is the player pref old associated round
            associatedRoundText.text = "Associated Round: " + newRoundNumber.ToString();
            PlayerPrefs.SetInt("OldAssociatedRound", newRoundNumber);

            PlayerPrefs.Save();
        }
    }


    public void clearData()
    {
        PlayerPrefs.DeleteKey("RoundNumber");
        PlayerPrefs.DeleteKey("ScrapAmount");
        PlayerPrefs.DeleteKey("OldHighestRoundNumber");
        PlayerPrefs.DeleteKey("OldHighestScrapAmount");
        PlayerPrefs.Save();
        QuitGame();
    }

    // Your other code here...

    // Call this method when you want to quit the game
    public void QuitGame()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}
