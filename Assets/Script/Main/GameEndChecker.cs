using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameEndChecker : MonoBehaviour {

    public GameObject ifYouAreDrunkDontSingPanel;
    public float countDownUntilMain;

    private SceneLoader sceneLoader;
    private PointController pointController;
    
    private bool failed;

	void Start () {
        ifYouAreDrunkDontSingPanel.SetActive(false);
        sceneLoader = FindObjectOfType<SceneLoader>();
        pointController = FindObjectOfType<PointController>();

        failed = false;
    }
	
	void Update () {
	    if (failed)
        {
            countDownUntilMain -= Time.deltaTime;
            if (countDownUntilMain <= 0)
            {
                sceneLoader.LoadMenu();
            }
        }

	}

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "EndGameCollider" && !failed)
        {
            ifYouAreDrunkDontSingPanel.SetActive(true);
            pointController.DisableCollectingAndSubmitScore();
            failed = true;
        }
    }
}
