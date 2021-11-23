using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadRoad : MonoBehaviour
{

    private void OnTriggerExit(Collider other)
    {
            RoadSpawn.instance.SpawnRoad();
            Destroy(gameObject, 2f);
            //Debug.Log("ªË¡¶ ¡ﬂ1");

    }
}
