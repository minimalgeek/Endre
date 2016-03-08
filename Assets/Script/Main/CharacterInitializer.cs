using UnityEngine;
using System.Collections;

public class CharacterInitializer : MonoBehaviour {

    public GameObject[] characterPrefabs;
    public string prefix;

    void Start () {
        int choosenCharacterIdx = SaveLoad.data.actualSkin.id;
        string prefabNameToSearch = prefix + choosenCharacterIdx;

        foreach(GameObject obj in characterPrefabs)
        {
            if (obj.name == prefabNameToSearch)
            {
                Instantiate(obj, Vector2.zero, Quaternion.identity);
                break;
            }
        }
	}
}
