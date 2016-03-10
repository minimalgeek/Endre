using UnityEngine;
using UnityEngine.UI;

public class RisingText : MonoBehaviour
{
    private Vector2 speedVector;
    private float currentAlpha;
    private float fadeDuration;

    public float duration;
    public float upSpeed;
    
    public void Init(string textToShow)
    {
        Text textComponent = GetComponent<Text>();
        textComponent.text = textToShow;
    }

    void Start()
    {
        fadeDuration = 1f / duration;
        speedVector = new Vector2(0f, upSpeed);

        currentAlpha = 1f;
        fadeDuration = 0.5f;
    }

    void Update() 
    {
        // Move upwards
        transform.Translate(speedVector * Time.deltaTime, Space.World);

        // Change alpha
        currentAlpha -= Time.deltaTime * fadeDuration;
        Color color = GetComponent<Text>().color;
        color.a = currentAlpha;
        GetComponent<Text>().color = color;

        // If completely faded out, die
        if (currentAlpha <= 0f) Destroy(gameObject);
    }
}
