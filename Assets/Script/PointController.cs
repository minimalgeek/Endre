using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PointController : MonoBehaviour {

    public Text pointText;
    private float points;

	void Start () {
        points = 0f;
	}
	
	// Update is called once per frame
	void Update () {
        points += Time.deltaTime * 100;
	}

    void OnGUI()
    {
        pointText.text = ((int)points).ToString();
    }
}
