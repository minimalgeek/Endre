using UnityEngine;
using System.Collections;

public class BeerSpawner : MonoBehaviour {

    public GameObject leftSpawner;
    public GameObject rightSpawner;

    public GameObject objectToSpawn;

    private bool left = false;

    public float forceApplyTime;
    private float timeCounter;

    public int horizontalForce;
    public int verticalForce;
    public int rotationForce;
    public float destroyTime;

    public int forceIncrease;

    void Start () {
        timeCounter = forceApplyTime;
    }
	
	void Update () {
        float dt = Time.deltaTime;
        timeCounter -= dt;

        if (timeCounter <= 0)
        {
            GameObject instantiated = (GameObject) Instantiate(
                objectToSpawn, 
                left ? leftSpawner.transform.position : rightSpawner.transform.position, 
                Quaternion.identity);

            Destroy(instantiated, destroyTime);

            int direction = left ? 1 : -1;

            Rigidbody2D body = instantiated.GetComponent<Rigidbody2D>();
            body.AddRelativeForce(new Vector2(direction * horizontalForce, verticalForce));
            body.AddTorque(rotationForce);

            timeCounter = forceApplyTime;
            horizontalForce += forceIncrease;
            left = !left;
        }
    }
}
