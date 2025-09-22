using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class saveInfoGameOver : MonoBehaviour
{
    public RoundSystem roundSystemInstance;
    public scrapCollection playerScrapSys;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void saveInfoPlayerPref()
    {
        int currRound = roundSystemInstance.getCurrentRound();
        int currScrap = playerScrapSys.getCurrentScrap();

        PlayerPrefs.SetInt("RoundNumber", currRound);
        PlayerPrefs.SetInt("ScrapAmount", currScrap);
        PlayerPrefs.Save();
    }
}
