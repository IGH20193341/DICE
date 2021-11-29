using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadRoad2 : MonoBehaviour
{

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //Debug.Log("����");
            RoadSpawn.instance.SpawnRoad();
            Destroy(gameObject, 2f);
            //Debug.Log("���� ��2");
        }
    }
}
