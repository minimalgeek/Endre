using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PointController : MonoBehaviour {

    public Text pointText;
    public Text endPointsText;
    public Text beerMultiplierText;
    public Text sumPointsText;
    public GameObject pointPanel;

    public float steelHeartPointsToAdd = 1500f;
    public float steelheartIncrement = 500f;

    private float points;
    private bool shouldCollect = true;
    private BeerSpawner spawner;
    
    void Start () {
        points = 0;
        spawner = FindObjectOfType<BeerSpawner>();
    }
	
	// Update is called once per frame
	void Update () {
        if (shouldCollect)
        {
            points += (Time.deltaTime * 100);
        }
	}

    void OnGUI()
    {
        pointText.text = ((int)points).ToString();
    }

    public void DisableCollectingAndSubmitScore()
    {
        if (shouldCollect)
        {
            int pointsCollected = (int)points;
            float multiplier = spawner.CalculateMultiplier();
            int sumPoints = (int)(pointsCollected * multiplier);

            endPointsText.text = pointsCollected + SceneLoader.VOL;
            beerMultiplierText.text = multiplier + SceneLoader.MULT;
            sumPointsText.text = sumPoints + SceneLoader.VOL;

            SaveLoad.data.AddScore(sumPoints);
            SaveLoad.Save();

            pointPanel.SetActive(false);
            shouldCollect = false;
        }
    }

    public float AddPoints()
    {
        steelHeartPointsToAdd += steelheartIncrement;
        points += steelHeartPointsToAdd;

        return steelHeartPointsToAdd;
    }
}
