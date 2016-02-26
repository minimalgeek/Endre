using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PointController : MonoBehaviour {

    public Text pointText;
    private float points;
    private bool shouldCollect = true;

    void Start () {
        points = 0;
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

    public void DisableCollecting()
    {
        if (shouldCollect)
        {
            SaveLoad.data.AddScore((int)points);
            SaveLoad.Save();
        }
        shouldCollect = false;
    }
}
