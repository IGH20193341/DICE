using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadSpawn : MonoBehaviour
{
    public GameObject LoadRoad;

    Vector3 nextroad;

    public static RoadSpawn instance;

    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        for(int i = 0; i < 15; i++)
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
        GameObject temp = Instantiate(LoadRoad, nextroad, Quaternion.identity); // LoadRoad��� ������Ʈ�� nextroad��ġ�� ����(ȸ������ ����)
        nextroad = temp.transform.GetChild(1).transform.position; // nextroad ��ġ�� temp�� transform�� 2��° ��ġ�� �ִ� transform�� ��ġ�� ����
    }
}
