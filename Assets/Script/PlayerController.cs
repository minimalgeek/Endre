using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    private Rigidbody2D myRigidBody;
    private bool kickLeft;
    private bool kickRight;
    private bool kickUp;

    public int verticalForce;
    public int horizontalForce;

	void Start () {
        myRigidBody = GameObject.Find("Body").GetComponent<Rigidbody2D>();
    }
	
	
	void Update () {
        HandleInput();
	}

    void FixedUpdate()
    {
        if (kickLeft)
        {
            myRigidBody.AddForce(new Vector2(verticalForce, horizontalForce));
        }

        if (kickRight)
        {
            myRigidBody.AddForce(new Vector2(-verticalForce, horizontalForce));
        }

        if (kickUp)
        {
            myRigidBody.AddForce(new Vector2(0, horizontalForce));
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
        } else
        {
            kickRight = true;
        }

        if (pos.y < Screen.height / 4)
        {
            kickUp = true;
        }
    }

    private void ResetValues()
    {
        kickLeft = false;
        kickRight = false;
        kickUp = false;
    }
    
}
