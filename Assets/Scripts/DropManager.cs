using UnityEngine;
using System.Collections;
public class DropManager : MonoBehaviour
{
    public GameObject[] ObjPrefabs;
    public float spawnY = 10f;
    public float minX = -4f;
    public float maxX = 4f;
    public float spawnDelay = 1f;

    private GameObject CurrentObj;
    private Camera mainCamera;
    private bool canDrop = true;
    private bool gameActive = true;

    static public DropManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        mainCamera = Camera.main;
        SpawnObject();  
    }

    void Update()
    {
        if (CurrentObj == null) return;

        if (!gameActive) return;

        Vector3 mousePos = Input.mousePosition;
        mousePos.z = -mainCamera.transform.position.z;
        Vector3 worldPos = mainCamera.ScreenToWorldPoint(mousePos);

        float x = Mathf.Clamp(worldPos.x, minX, maxX);

        CurrentObj.transform.position = new Vector3(x, spawnY, 0);

        if (Input.GetMouseButtonDown(0) && canDrop)
        {
            DropObject();
        }

    }
    void SpawnObject()
    {
        int randomValue = Random.Range(0, 100);

        int randomIndex;

        if (randomValue < 55)
        {
            randomIndex = 0;
        }
        else if (randomValue < 85)
        {
            randomIndex = 1;
        }
        else
        {
            randomIndex = 2;
        }

        GameObject selected = ObjPrefabs[randomIndex];

        CurrentObj = Instantiate(selected, new Vector3(0, spawnY, 0), Quaternion.identity);

        Rigidbody2D rb = CurrentObj.GetComponent<Rigidbody2D>();

        if (rb != null)
        {
            rb.bodyType = RigidbodyType2D.Kinematic;
        }

        canDrop = true;
    }

    void DropObject()
    {
        Rigidbody2D rb = CurrentObj.GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Dynamic;
        CurrentObj = null;
        canDrop = false;
        StartCoroutine(SpawnNextObj());
    }

    IEnumerator SpawnNextObj()
    {
        yield return new WaitForSeconds(spawnDelay);
        SpawnObject();
    }

    public void StopDropping()
    {
        gameActive = false;

        StopAllCoroutines();

        if (CurrentObj != null)
        {
            Destroy(CurrentObj);
            CurrentObj = null;
        }
    }
}
