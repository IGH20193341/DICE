using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawn : MonoBehaviour
{
    public GameObject CoinObject;
    GameObject coin;

    float randomX;
    float randomY;
    float[] Yrange = { 0.5f, 3 };
    float randomZ;

    float zDistance = 100;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnCoin", 1, 0.5f);
    }
    void SpawnCoin()
    {
        randomX = Random.Range(-2, 2);

        if (zDistance >= 345 && zDistance < 355)
        {
            Yrange[0] = -30;
            Yrange[1] = -30;
        }

        if (zDistance >= 355)
        {
            Yrange[0] = -0.5f;
            Yrange[1] = 2f;
        }

        randomY = Yrange[Random.Range(0, 2)];
        randomZ = Random.Range(zDistance, zDistance);

        coin = Instantiate(CoinObject, new Vector3(randomX, randomY, randomZ), Quaternion.identity);
        zDistance += 75;
    }
}
