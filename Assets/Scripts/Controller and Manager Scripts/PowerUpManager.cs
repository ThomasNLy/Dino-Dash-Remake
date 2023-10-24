using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    [Header("Prefabs to spawn")]
    public GameObject powerupPrefab;



    [Header("Spawn and despawn loc")]
    public Transform spawnLoc;
    public Transform despawnLoc;

    [Header("Debug")]
    [SerializeField]
    private GameObject[] prefabList = new GameObject[3];
    [SerializeField]
    private float spawnDelay = 5f;
    [SerializeField]
    private int index;
    private float timer = 0f;

    public static PowerUpManager Instance;

    private void Awake()
    {

        if (this != Instance && Instance != null)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
            Init();
        }
        
        
    }


    // Start is called before the first frame update
    void Start()
    {
        index = 0;
    }

    /**
     * spawns in the power up prefab and sets its parent to be the power up manager 
     */
    public void Init()
    {
        Vector3 startingLoc = spawnLoc.position + (Vector3.down  * 20);
        
        for (int i = 0; i < prefabList.Length; i++)
        {
            prefabList[i] = Instantiate(powerupPrefab, startingLoc, Quaternion.identity);

            //set the parent to the power up manager and keep it's transform component to be world space rather than relative to parent
            prefabList[i].transform.SetParent(this.gameObject.transform, true);
        }

    }
    // Update is called once per frame
    void Update()
    {
        RespawnObject();
    }


    private void RespawnObject()
    {
        GameObject currentObj = prefabList[index];
        timer += Time.deltaTime;
        if (timer > spawnDelay)
        {
            timer = 0f;
            if (currentObj.transform.position.x < despawnLoc.position.x)
            {
                float randomYpos = Random.Range(0, 5);
                currentObj.GetComponent<ObstacleSpriteObject>().Spawn(spawnLoc.position + (Vector3.up * randomYpos));
            }
        }
        index++;
        if (index > prefabList.Length - 1)
        {
            index = 0;
        }
    }
}
