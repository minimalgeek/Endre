using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameEndChecker : MonoBehaviour {

    public GameObject ifYouAreDrunkDontSingPanel;
    private PointController pointController;
    
    private bool failed;

	void Start () {
        ifYouAreDrunkDontSingPanel.SetActive(false);
        pointController = FindObjectOfType<PointController>();
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "EndGameCollider" && !failed)
        {
            ifYouAreDrunkDontSingPanel.SetActive(true);
            pointController.DisableCollectingAndSubmitScore();
        }
    }
}
