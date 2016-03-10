using UnityEngine;
using System.Collections;

public class SteelHeartInitializer : MonoBehaviour {

    public float secondsUntilFirstHeart;
    public float minSeconds;
    public float maxSeconds;
    public float heartAliveTime;
    public GameObject steelHeart;

    private bool enabled = false;

	void Start () {
        StartCoroutine(WaitSeconds());
    }
	
	void Update () {
        if (enabled)
        {
            enabled = false;
            StartCoroutine(InitHeart());
        }
    }

    private IEnumerator WaitSeconds()
    {
        yield return new WaitForSeconds(secondsUntilFirstHeart);
        enabled = true;
    }

    private IEnumerator InitHeart()
    {
        float secondsUntilHeart = Random.Range(minSeconds, maxSeconds);
        yield return new WaitForSeconds(secondsUntilHeart);
        Vector2 posOnInit = new Vector2();
        posOnInit.x = Random.Range(-2.0f, 2.0f);
        posOnInit.y = Random.Range(-4.0f, 4.0f);
        GameObject obj = (GameObject)Instantiate(steelHeart, posOnInit, Quaternion.identity);
        Destroy(obj, heartAliveTime);
        enabled = true;
    }
}
