using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameEndChecker : MonoBehaviour {

    private const string DSP = "DontSingPanel";
    private const string CANVAS = "Canvas";

    private GameObject canvas;
    private GameObject ifYouAreDrunkDontSingPanel;
    private PointController pointController;
    
    private bool failed;

	void Start () {
        failed = false;
        canvas = GameObject.Find(CANVAS);
        ifYouAreDrunkDontSingPanel = canvas.FindObject(DSP);
        ifYouAreDrunkDontSingPanel.SetActive(false);
        pointController = FindObjectOfType<PointController>();
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "EndGameCollider" && !failed)
        {
            failed = true;
            ifYouAreDrunkDontSingPanel.SetActive(true);
            pointController.DisableCollectingAndSubmitScore();
        }
    }
}
