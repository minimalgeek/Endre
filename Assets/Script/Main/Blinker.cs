﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Blinker : MonoBehaviour {

    private CanvasGroup group;
    public float duration = 0.15f;

    void Start()
    {
        group = this.gameObject.GetComponent<CanvasGroup>();
        StartCoroutine(DoBlinks(duration, 0.2f));
    }

    IEnumerator DoBlinks(float duration, float blinkTime)
    {
        while (duration > 0f)
        {
            duration -= Time.deltaTime;

            //toggle renderer
            group.alpha = group.alpha == 1 ? 0 : 1;

            //wait for a bit
            yield return new WaitForSeconds(blinkTime);
        }

        Destroy(gameObject);
        Destroy(gameObject.transform.parent.gameObject);
    }
}