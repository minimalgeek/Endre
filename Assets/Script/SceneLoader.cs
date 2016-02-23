using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {

    private const string MAIN = "Main";
    private const string MENU = "Menu";

    public GameObject weaponPanel;
    public GameObject skinPanel;

    void Awake()
    {
        SaveLoad.Load();
    }

    void Start () {
    }
	
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (SceneManager.GetActiveScene().name == MAIN)
            {
                LoadMenu();
            } else
            {
                if (weaponPanel && weaponPanel.activeInHierarchy)
                {
                    weaponPanel.SetActive(false);
                }
                else if (skinPanel && skinPanel.activeInHierarchy)
                {
                    skinPanel.SetActive(false);
                }
                else
                {
                    Application.Quit();
                }
            }
            
        }
    }

    public void LoadMain()
    {
        SceneManager.LoadScene(MAIN);
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene(MENU);
    }
}
