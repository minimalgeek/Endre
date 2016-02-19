using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HighScoreUI : MonoBehaviour {

    private GameData gameData;
    public GameObject[] results;

    void Awake()
    {
        gameData = SaveLoad.Load();
    }
    
	void Start () {
        if (gameData.bestScores != null)
        {
            gameData.SortBestScores();
            for (int i = 0; i < results.Length; i++)
            {
                int score = gameData.bestScores[gameData.bestScores.Length - 1 - i];
                if (score > 0)
                {
                    results[i].GetComponent<Text>().text = score.ToString();
                }
            }
        }
    }
	
}
