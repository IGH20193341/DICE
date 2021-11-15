using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadRoad2 : MonoBehaviour
{

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("감지");
        RoadSpawn.instance.SpawnRoad();
        Destroy(gameObject, 2f);
        Debug.Log("삭제 중2");
    }
}
