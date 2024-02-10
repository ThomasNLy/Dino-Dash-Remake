using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    public static ObstacleManager Instance;
    
    
    [Header("Spawn Location and Despawn Location")]
    public Transform spawnLocation;
    public Transform despawnLocation;
    [Header("Prefab to spawn")]
    public GameObject obstaclePrefab;

    [Header("Debug")]
    [SerializeField]
    GameObject [] obstacleList;
    int index;

    [SerializeField]
    float timer;
    [SerializeField]
    float spawnTimerDelay = 5f;

    private void Awake()
    {

        if (Instance != this && Instance != null)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
            Init();
        }

        
    }

    void Init()
    {
        timer = 0f;
        obstacleList = new GameObject[5];
        Vector3 startingLoc = spawnLocation.position + (Vector3.down * 30);
        
        for (int i = 0; i < obstacleList.Length; i++)
        {

            ObstacleSpriteObject obj = Instantiate(obstaclePrefab).GetComponent<ObstacleSpriteObject>();
            obj.Init(startingLoc);
            obj.transform.SetParent(GameObject.Find("World").transform, true);
            obstacleList[i] = obj.gameObject;

        }
    }
    // Start is called before the first frame update
    void Start()
    {
        index = 0;
    }

    // Update is called once per frame
    void Update()
    {
        RespawnObject();
   
       
    }

    private void RespawnObject()
    {
        GameObject currentObj = obstacleList[index];
        timer += Time.deltaTime;
        if (timer > spawnTimerDelay)
        {
            timer = 0f;
           
            if (currentObj.transform.position.x < despawnLocation.position.x)
            {
                currentObj.GetComponent<ObstacleSpriteObject>().Spawn(spawnLocation.position);
            }
        }
        index++;
        if (index > obstacleList.Length - 1)
        {
            index = 0;
        }
    }

    public float SpawnTimerDelay
    {
        get { return spawnTimerDelay; }
        set { spawnTimerDelay = value; }
    }
}
