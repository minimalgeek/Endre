using System;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class GameData {

    public int[] bestScores;
    public long sumOfScores = 0;

    public Skin actualSkin;
    public Weapon actualWeapon;

    public GameData()
    {
        actualSkin = new Skin();
        actualWeapon = new Weapon();
        bestScores = new int[5];
    }

    public void AddScore(int scoreToAdd)
    {
        SortBestScores();

        if (bestScores[0] < scoreToAdd)
        {
            bestScores[0] = scoreToAdd;
        }

        sumOfScores += scoreToAdd;
    }

    public void SortBestScores()
    {
        Array.Sort<int>(bestScores);
    }
    
}
