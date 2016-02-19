using System;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class GameData {

    public int[] bestScores;

    public void TryToAddBestScore(int scoreToAdd)
    {
        if (bestScores == null)
        {
            bestScores = new int[5];
        }

        SortBestScores();

        if (bestScores[0] < scoreToAdd)
        {
            bestScores[0] = scoreToAdd;
        }
    }

    public void SortBestScores()
    {
        Array.Sort<int>(bestScores);
    }
    
}
