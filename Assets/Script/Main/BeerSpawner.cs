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

    public int verticalForce;
    public int rotationForce;
    public float destroyTime;

    public SideGroup left;
    public SideGroup right;

    private long spawnedBeers = 0;

    void Start () {
        
    }

    void Update()
    {
        HandlePanelCooldown();
        HandleInput();
    }

    public float CalculateMultiplier()
    {
        return 1f + spawnedBeers / 100f;
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
                for (int i = 0; i < Input.touchCount; i++)
                {
                    if (Input.GetTouch(i).phase == TouchPhase.Began)
                    {
                        CheckTouch(Input.GetTouch(i).position);
                    }
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

    private void CheckTouch(Vector2 touchPos)
    {
        SideGroup group = touchPos.x < Screen.width / 2 ? left : right;
        group.Fire();
        InitBottle(group, touchPos);
        spawnedBeers++;
    }

    private void InitBottle(SideGroup group, Vector2 touchPos) {
        Vector2 posInit = group.spawner.transform.position;
        posInit.y = Camera.main.ScreenToWorldPoint(touchPos).y;

        GameObject instantiated = (GameObject)Instantiate(
            objectToSpawn,
            posInit,
            Quaternion.identity);

        Destroy(instantiated, destroyTime);

        Rigidbody2D body = instantiated.GetComponent<Rigidbody2D>();
        body.AddRelativeForce(new Vector2(group.directionMultiplier * SaveLoad.data.actualWeapon.horizontalForce, verticalForce));
        body.AddTorque(group.directionMultiplier * rotationForce);
    }
    
}
