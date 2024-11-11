using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentManager : MonoBehaviour
{
    public static EnvironmentManager Instance;
    public List<GameObject> bigObstacleList = new List<GameObject>();
    public List<GameObject> smallObstacleList = new List<GameObject>();
    public GameObject point;
    public float mapDistance = 96;
    public Environment map_prefabs;
    public List<Environment> mapList = new List<Environment>();
    public Environment currentMap;
    public Transform playerPos;
    public int mapCount = 0;
    //public float speed = 8f;

    public int objectCount = 1;
    public int obstacleChance = 2;
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        SpawnMap();
    }
    private void Update()
    {
        if (!GameManager.Instance.isPlaying) return;
        MoveEnvironment();
        CheckAndSpawnBackground();
    }
    void MoveEnvironment() 
    {
        transform.position -= new Vector3(0, 0, Time.deltaTime * Player.instance.speed);
    }
    void CheckAndSpawnBackground()
    {
        if (playerPos.position.z >= currentMap.startPoint.position.z)
        {
            SpawnMap();
        }
    }
    void SpawnMap()
    {
        DifficultCurve();
        if (mapList.Count >= 3)
        {
            Destroy(mapList[0].gameObject);
            mapList.RemoveAt(0);
        }
        Environment _go = Instantiate(map_prefabs, transform);
        _go.transform.position = new Vector3(0,0, currentMap.transform.position.z + mapDistance);
        mapList.Add(_go);
        currentMap = _go;
        mapCount++;
        Player.instance.SetSpeed();
    }
    void DifficultCurve()
    {
        if (mapCount <= 10)
        {
            objectCount = 1;
            obstacleChance = 2;
        }
        else if (mapCount <= 20)
        {
            objectCount = 2;
            obstacleChance = 3;
        }
        else if (mapCount <= 30)
        {
            
        }
        else if (mapCount <= 40)
        {
            obstacleChance = 4;
        }
        else if (mapCount <= 50)
        {
            objectCount = 3;
            obstacleChance = 4;
        }
        else if (mapCount <= 60)
        {
            obstacleChance = 4;
        }
        else if (mapCount <= 70)
        {
            obstacleChance = 5;
        }
        else if (mapCount <= 80)
        {
            obstacleChance = 6;
            objectCount = 4;
        }
        else if (mapCount <= 90)
        {
            obstacleChance = 7;
        }
        else if (mapCount <= 100)
        {
            obstacleChance = 8;
            objectCount = 5;
        }
        else
        {
            obstacleChance = 9;
        }
    }
}
