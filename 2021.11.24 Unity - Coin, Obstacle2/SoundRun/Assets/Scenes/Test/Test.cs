using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{

    public GameObject Enemy;
    float MinZ = 0;
    float MaxZ = 0;
    void SpawnEnemy()
    {
        float randomX = Random.Range(-10, 10);
        float randomZ = Random.Range(MinZ, MaxZ);

        GameObject enemy = (GameObject)Instantiate(Enemy, new Vector3(randomX, 0, randomZ), Quaternion.identity);
        MinZ += 1;
        MaxZ += 1;
        Destroy(enemy, 2f);
    }
    void Start()
    {
        InvokeRepeating("SpawnEnemy", 3, 1); //3초후 SpawnEnemy함수를 호출하고 그 후 1초마다 SpawnEnemy함수 호출
    }
    void Update()
    {

    }
}
