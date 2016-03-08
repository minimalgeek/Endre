using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AwardTextGenerator : MonoBehaviour {

    public Text awardText;

    public string[] awards;

	void Start () {
        awardText.text = "\"" + awards[Random.Range(0, awards.Length)] + "\"";
	}
}
