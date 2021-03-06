﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HighScoreUI : MonoBehaviour {

    public GameObject[] results;
    public GameObject totalScoreNumber;
    
	void Start () {
        if (SaveLoad.data.bestScores != null)
        {
            SaveLoad.data.SortBestScores();
            for (int i = 0; i < results.Length; i++)
            {
                int score = SaveLoad.data.bestScores[SaveLoad.data.bestScores.Length - 1 - i];
                if (score > 0)
                {
                    results[i].GetComponent<Text>().text = score.ToString() + SceneLoader.VOL;
                }
            }
        }
    }

    void OnGUI()
    {
        totalScoreNumber.GetComponent<Text>().text = SaveLoad.data.sumOfScores + SceneLoader.VOL;
    }
	
}
