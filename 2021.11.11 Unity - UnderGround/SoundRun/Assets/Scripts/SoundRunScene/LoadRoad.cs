using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadRoad : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerExit(Collider other)
    {
        if (transform.position.z > -10 && transform.position.z < 90)
        {
            RoadSpawn.instance.SpawnRoad();
            Destroy(gameObject, 2f);
            //Debug.Log("삭제 중1");
        }
        else if(transform.position.z >= 90)
        {
            Destroy(gameObject, 2f);
           // Debug.Log("삭제중 2");
        }

    }
}
