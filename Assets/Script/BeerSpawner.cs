using UnityEngine;
using System.Collections;

[System.Serializable]
public class SideGroup
{
    public GameObject spawner;
    public GameObject panel;
    [System.NonSerialized]
    public float coolDown;
    public int directionMultiplier;

    private const float panelCooldownTime = 0.1f;

    public void HandlePanelCooldown(float dt)
    {
        if (coolDown > 0)
        {
            coolDown -= dt;
        }
        else
        {
            panel.SetActive(false);
        }
    }

    public void Fire()
    {
        panel.SetActive(true);
        coolDown = panelCooldownTime;
    }
}

public class BeerSpawner : MonoBehaviour {
    
    public GameObject objectToSpawn;

    public int horizontalForce;
    public int verticalForce;
    public int rotationForce;
    public float destroyTime;

    public SideGroup left;
    public SideGroup right;

    void Start () {
        
    }

    void Update()
    {
        HandlePanelCooldown();
        HandleInput();
    }

    private void HandlePanelCooldown()
    {
        float dt = Time.deltaTime;
        left.HandlePanelCooldown(dt);
        right.HandlePanelCooldown(dt);
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
        SideGroup group = pos.x < Screen.width / 2 ? left : right;
        group.Fire();
        InitBottle(group);
    }

    private void InitBottle(SideGroup group) {
        GameObject instantiated = (GameObject)Instantiate(
            objectToSpawn,
            group.spawner.transform.position,
            Quaternion.identity);

        Destroy(instantiated, destroyTime);

        Rigidbody2D body = instantiated.GetComponent<Rigidbody2D>();
        body.AddRelativeForce(new Vector2(group.directionMultiplier * horizontalForce, verticalForce));
        body.AddTorque(rotationForce);
    }
    
}
