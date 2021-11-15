using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadSpawn : MonoBehaviour
{
    public GameObject LoadRoad, LoadRoad2;

    Vector3 nextroad = Vector3.zero;

    public static RoadSpawn instance;

    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        for(int i = 0; i < 25; i++)
        {
            SpawnRoad();

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnRoad()
    {

        if (nextroad.z >= 0 && nextroad.z <= 330)
        {
            GameObject temp = Instantiate(LoadRoad, nextroad, Quaternion.identity); // LoadRoad라는 오브젝트를 nextroad위치에 생성(회전값은 없다)
            nextroad = temp.transform.GetChild(1).transform.position; // nextroad 위치는 temp의 transform의 2번째 위치에 있는 transform의 위치에 생성
        }

        else if (nextroad.z >= 330)
        {
            nextroad.y = -1.5f;
            GameObject temp = Instantiate(LoadRoad2, nextroad, Quaternion.identity);
            nextroad = temp.transform.GetChild(1).transform.position;
        }
    }
}
