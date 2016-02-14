using UnityEngine;
using System.Collections;

public class SceneLoader : MonoBehaviour {

	void Start () {
	
	}
	
	void Update () {
	
	}

    public void LoadMain()
    {
        Application.LoadLevel("Main");
    }

    public void LoadMenu()
    {
        Application.LoadLevel("Menu");
    }
}
