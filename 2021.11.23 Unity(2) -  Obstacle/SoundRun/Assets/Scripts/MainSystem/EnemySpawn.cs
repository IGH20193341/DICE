using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject Enemy;
    GameObject enemy;
    float MinZ = 100;
    float MaxZ = 100;
    float Yrange = 0;
    void SpawnEnemy()
    {
        float randomX = Random.Range(-2, 2);
        float randomZ = Random.Range(MinZ, MaxZ);

        enemy = Instantiate(Enemy, new Vector3(randomX, Yrange, randomZ), Quaternion.identity);
        MinZ += 50;
        MaxZ += 50;

        if (MaxZ >= 330)
        {
            Yrange = -1;
        }
    }

    void Start()
    {
        InvokeRepeating("SpawnEnemy", 1, 0.5f); //1���� SpawnEnemy�Լ��� ȣ���ϰ� �� �� 0.5�ʸ��� SpawnEnemy�Լ� ȣ��
        
    }
    void Update()
    {

    }
}
