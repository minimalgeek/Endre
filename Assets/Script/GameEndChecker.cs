using UnityEngine;
using System.Collections;

public class GameEndChecker : MonoBehaviour {

    public GameObject ifYouAreDrunkDontSingPanel;
    private SceneLoader sceneLoader;
    public float countDownUntilMain;

    private bool failed;

	void Start () {
        ifYouAreDrunkDontSingPanel.SetActive(false);
        sceneLoader = FindObjectOfType<SceneLoader>();

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

        if (coll.gameObject.tag == "PlayerHead")
        {
            ifYouAreDrunkDontSingPanel.SetActive(true);
            failed = true;
        }
    }
}
