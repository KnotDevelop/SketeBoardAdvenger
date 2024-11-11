using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Environment : MonoBehaviour
{
    public Transform allObstacle;
    public bool isStart = false;
    public Transform startPoint;
    //public Transform allScorePoint;
    private void Start()
    {
        if (isStart) return;
        SpawnObstacle();
    }

    void SpawnObstacle()
    {
        int _bigObstacleCount = 2;
        for (int i = 0; i < allObstacle.childCount; i++)
        {
            List<int> _rnList = GenerateUniqueRandomNumbers(0, allObstacle.GetChild(i).childCount, EnvironmentManager.Instance.objectCount);
            for (int j = 0; j < _rnList.Count; j++)
            {
                int _rObjType = Random.Range(0, 10);
                if (_rObjType <= EnvironmentManager.Instance.obstacleChance)
                {
                    int _rObjSize = Random.Range(0, 2);
                    GameObject obscleOBJ;
                    int _rn;
                    if (_rObjSize == 0 && _bigObstacleCount > 0)
                    {
                        _rn = Random.Range(0, EnvironmentManager.Instance.bigObstacleList.Count);
                        obscleOBJ = EnvironmentManager.Instance.bigObstacleList[_rn];
                        _bigObstacleCount--;
                    }
                    else 
                    {
                        _rn = Random.Range(0, EnvironmentManager.Instance.smallObstacleList.Count);
                        obscleOBJ = EnvironmentManager.Instance.smallObstacleList[_rn];
                    }
                    
                    GameObject _go = Instantiate(obscleOBJ);
                    _go.transform.SetParent(allObstacle.GetChild(i).GetChild(_rnList[j]));
                    _go.transform.localPosition = Vector3.zero;
                    _go.name = "Obstacle";
                }
                else 
                {
                    GameObject _go = Instantiate(EnvironmentManager.Instance.point);
                    _go.transform.SetParent(allObstacle.GetChild(i).GetChild(_rnList[j]));
                    _go.transform.localPosition = Vector3.zero;
                    _go.name = "ScoredPoint";
                }
            }
        }
    }

    List<int> GenerateUniqueRandomNumbers(int min, int max, int count)
    {
        if (count > max - min + 1)
        {
            Debug.LogError("Count cannot exceed the range of possible numbers.");
            return null;
        }

        HashSet<int> uniqueNumbers = new HashSet<int>();
        List<int> resultList = new List<int>();

        while (uniqueNumbers.Count < count)
        {
            int randomNumber = Random.Range(min, max);
            if (!uniqueNumbers.Contains(randomNumber))
            {
                uniqueNumbers.Add(randomNumber);
                resultList.Add(randomNumber);
            }
        }

        return resultList;
    }
}
