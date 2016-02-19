using UnityEngine;
using System.Collections;

public class Blinker : MonoBehaviour {

    private SpriteRenderer myRenderer;

    void Start()
    {
        myRenderer = gameObject.GetComponent<SpriteRenderer>();
        StartCoroutine(DoBlinks(0.15f, 0.2f));
    }

    IEnumerator DoBlinks(float duration, float blinkTime)
    {
        while (duration > 0f)
        {
            duration -= Time.deltaTime;

            //toggle renderer
            myRenderer.enabled = !myRenderer.enabled;

            //wait for a bit
            yield return new WaitForSeconds(blinkTime);
        }

        Destroy(gameObject);
    }
}
