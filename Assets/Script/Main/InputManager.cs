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

public class InputManager : MonoBehaviour
{

    private GameObject objectToSpawn;
    private GameObject canvas;
    private PointController pointController;

    public LayerMask layerToDestroy;
    public GameObject flyingText;

    public GameObject[] bottlePrefabs;
    public int verticalForce;
    public int rotationForce;
    public float destroyTime;

    public SideGroup left;
    public SideGroup right;

    private long spawnedBeers = 0;

    void Start()
    {
        canvas = GameObject.Find("Canvas");
        pointController = FindObjectOfType<PointController>();

        int choosenCharacterIdx = SaveLoad.data.actualWeapon.id;
        string prefabNameToSearch = "Bottle" + choosenCharacterIdx;

        foreach (GameObject obj in bottlePrefabs)
        {
            if (obj.name == prefabNameToSearch)
            {
                objectToSpawn = obj;
                break;
            }
        }
    }

    void Update()
    {
        HandlePanelCooldown();
        HandleInput();
    }

    public float CalculateMultiplier()
    {
        return 1f + spawnedBeers / 1000f;
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

    private void CheckTouch(Vector2 pos)
    {
        Vector3 wp = Camera.main.ScreenToWorldPoint(pos);
        Vector2 touchPos = new Vector2(wp.x, wp.y);

        Collider2D hit = Physics2D.OverlapPoint(touchPos, layerToDestroy);
        if (hit)
        {
            Destroy(hit.gameObject);

            GameObject textObj = (GameObject)Instantiate(flyingText, pos, Quaternion.identity);
            textObj.transform.SetParent(canvas.transform);
            textObj.GetComponent<RisingText>().Init(AddCoinsAndCreateText());
        }
        else
        {
            SideGroup group = pos.x < Screen.width / 2 ? left : right;
            group.Fire();
            InitBottle(group, pos);
            spawnedBeers++;
        }
    }

    private void InitBottle(SideGroup group, Vector2 touchPos)
    {
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

    private string AddCoinsAndCreateText()
    {
        float added = pointController.AddPoints();
        return "+" + added + " Ft";
    }

}
