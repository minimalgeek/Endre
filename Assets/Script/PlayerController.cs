using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    private Rigidbody2D myRigidBody;
    private bool kickLeft;
    private bool kickRight;

    private GameObject leftPanel;
    private GameObject rightPanel;

    private float panelCoolDownTime = 0.1f;
    private float leftCoolDown, rightCoolDown;
    
    public int verticalForce;
    public int horizontalForce;

	void Start () {
        myRigidBody = GameObject.Find("Body").GetComponent<Rigidbody2D>();

        leftPanel = GameObject.Find("LeftPanel");
        rightPanel = GameObject.Find("RightPanel");

        leftPanel.SetActive(false);
        rightPanel.SetActive(false);
    }
	
	
	void Update () {
        float dt = Time.deltaTime;

        if (leftCoolDown > 0)
        {
            leftCoolDown -= dt;
        } else
        {
            leftPanel.SetActive(false);
        }

        if (rightCoolDown > 0)
        {
            rightCoolDown -= dt;
        }
        else
        {
            rightPanel.SetActive(false);
        }

        HandleInput();
	}

    void FixedUpdate()
    {
        if (kickLeft)
        {
            myRigidBody.AddRelativeForce(new Vector2(horizontalForce, verticalForce));
        }

        if (kickRight)
        {
            myRigidBody.AddRelativeForce(new Vector2(-horizontalForce, verticalForce));
        }

        ResetValues();
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
        if (pos.x < Screen.width / 2)
        {
            kickLeft = true;

            leftPanel.SetActive(true);
            leftCoolDown = panelCoolDownTime;
        } else
        {
            kickRight = true;

            rightPanel.SetActive(true);
            rightCoolDown = panelCoolDownTime;
        }
    }

    private void ResetValues()
    {
        kickLeft = false;
        kickRight = false;
    }
    
}
