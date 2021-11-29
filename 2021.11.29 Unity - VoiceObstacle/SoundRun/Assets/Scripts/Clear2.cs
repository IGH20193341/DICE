using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clear2 : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "BigEnemy")
        {
            Destroy(other.gameObject);
        }
    }
}
