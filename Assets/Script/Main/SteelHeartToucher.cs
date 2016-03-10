using UnityEngine;
using System.Collections;

public class SteelHeartToucher : MonoBehaviour
{
    private const string STEEL_HEART = "SteelHeart";

    public GameObject flyingText;
    private GameObject canvas;
    private PointController pointController;

    void Start()
    {
        canvas = GameObject.Find("Canvas");
        pointController = FindObjectOfType<PointController>();
    }

    void Update()
    {
        HandleInput();
    }

    private void HandleInput()
    {
        if (Application.platform == RuntimePlatform.Android ||
            Application.platform == RuntimePlatform.IPhonePlayer)
        {
            if (Input.touchCount > 0)
            {
                if (Input.GetTouch(0).phase == TouchPhase.Began)
                {
                    CheckTouch(Input.GetTouch(0).position);
                }
            }
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                CheckTouch(Input.mousePosition);
            }
        }
    }

    private void CheckTouch(Vector2 pos)
    {
        Vector3 wp = Camera.main.ScreenToWorldPoint(pos);
        Vector2 touchPos = new Vector2(wp.x, wp.y);

        Collider2D hit = Physics2D.OverlapPoint(touchPos, LayerMask.NameToLayer(STEEL_HEART));

        if (hit && hit.gameObject.name == this.gameObject.name)
        {
            Destroy(this.gameObject);

            GameObject textObj = (GameObject)Instantiate(flyingText, Camera.main.WorldToScreenPoint(wp), Quaternion.identity);
            textObj.transform.SetParent(canvas.transform);
            textObj.GetComponent<RisingText>().Init(AddCoinsAndCreateText());
        }
    }

    private string AddCoinsAndCreateText()
    {
        float added = pointController.AddPoints();
        return "+" + added + " Ft";
    }
}
