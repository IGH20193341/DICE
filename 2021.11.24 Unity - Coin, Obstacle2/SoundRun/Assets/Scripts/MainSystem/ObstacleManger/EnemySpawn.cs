using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemySpawn : MonoBehaviour
{
    static int MAX = 6;
    public GameObject[] BigEnemy = new GameObject[MAX];
    public GameObject[] SmallEnemy = new GameObject[MAX];
    int[] RandomNum = { 0, 1, 2, 3, 4 };
    int RandomEnemy;
    float zDistance_B = 600;
    float zDistance_S = 300;
    float Xrange = 0;
    float Yrange = 0;

    void Start()
    {
            InvokeRepeating("SpawnBigEnemy", 6, 18); //5초후 SpawnBigEnemy함수를 호출하고 그 후 20초마다 SpawnBigEnemy함수 호출
            InvokeRepeating("SpawnSmallEnemy", 1, 1);
    }
    void SpawnBigEnemy()
    {
        //float randomX = Random.Range(-2, 2);
        float randomZ = Random.Range(zDistance_B, zDistance_B);

        RandomEnemy = RandomNum[Random.Range(0, 3)];

        if(RandomEnemy == 0)
        {
            Xrange = -10;
        }
        else if(RandomEnemy == 1)
        {
            Xrange = 10;
        }
        else if (RandomEnemy == 2)
        {
            Xrange = 2.5f;
            Yrange = 250;
        }

        GameObject temp = Instantiate(BigEnemy[RandomEnemy], new Vector3(Xrange, Yrange, randomZ), Quaternion.identity);

        zDistance_B += 700;

        if (zDistance_B >= 330)
        {
            Yrange = -1;
        }

    }

    void SpawnSmallEnemy()
    {
        float randomX = Random.Range(-2, 2);
        float randomZ = Random.Range(zDistance_S, zDistance_S);

        RandomEnemy = RandomNum[Random.Range(0, 2)];

        if (RandomEnemy == 0)
        {
            randomX = 0;

        }

        if(zDistance_S >= 345 && zDistance_S <= 355)
        {
            Yrange = -30;
        }

        GameObject temp = Instantiate(SmallEnemy[RandomEnemy], new Vector3(randomX, Yrange, randomZ), Quaternion.identity);

        zDistance_S += 50;

        if (zDistance_S >= 330)
        {
            Yrange = -1;
        }
    }
}
