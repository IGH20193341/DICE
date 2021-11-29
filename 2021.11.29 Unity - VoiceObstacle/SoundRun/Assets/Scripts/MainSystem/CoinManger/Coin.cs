using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    void Update()
    {
       transform.Rotate(400 * Time.deltaTime, 0, 0);
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            CoinScore.score += 1;
            Destroy(gameObject);
        }


    }

}
