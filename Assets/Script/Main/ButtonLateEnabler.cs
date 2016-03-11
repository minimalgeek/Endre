using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ButtonLateEnabler : MonoBehaviour {

    public float sec = 1f;
    public GameObject parentPanel;

    private Button btn;

    void Start()
    {
        btn = gameObject.GetComponent<Button>();
        btn.interactable = false;
    }

    void Update() {
        if (parentPanel.activeInHierarchy)
        {
            StartCoroutine(LateCall());
        }
    }

    IEnumerator LateCall()
    {
        yield return new WaitForSeconds(sec);
        btn.interactable = true;
    }
}
