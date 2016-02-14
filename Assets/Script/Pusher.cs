using UnityEngine;
using System.Collections;

public class Pusher : MonoBehaviour {

    public int verticalForce;
    public int initialHorizontalForce;
    public int horizontalForceIncrement;

    public float forceApplyTime;
    private float timeCounter;

    private Rigidbody2D myRigidBody;

    void Start () {
        myRigidBody = GameObject.Find("Body").GetComponent<Rigidbody2D>();
        timeCounter = forceApplyTime;
    }
	
	void Update () {
        float dt = Time.deltaTime;

        timeCounter -= dt;

        if (timeCounter <= 0)
        {
            int direction = Random.Range(0, 1) == 0 ? -1 : 1;
            myRigidBody.AddRelativeForce(new Vector2(direction* initialHorizontalForce, verticalForce));
            timeCounter = forceApplyTime;
            initialHorizontalForce += horizontalForceIncrement;
        }
	}
}
