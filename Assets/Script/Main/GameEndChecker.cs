using UnityEngine;
using System.Collections;

public class GameEndChecker : MonoBehaviour {

    public GameObject ifYouAreDrunkDontSingPanel;
    private SceneLoader sceneLoader;
    private PointController pointController;
    public float countDownUntilMain;

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
            pointController.DisableCollecting();

            countDownUntilMain -= Time.deltaTime;
            if (countDownUntilMain <= 0)
            {
                sceneLoader.LoadMenu();
            }
        }

	}

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "EndGameCollider")
        {
            ifYouAreDrunkDontSingPanel.SetActive(true);
            failed = true;
        }
    }
}
