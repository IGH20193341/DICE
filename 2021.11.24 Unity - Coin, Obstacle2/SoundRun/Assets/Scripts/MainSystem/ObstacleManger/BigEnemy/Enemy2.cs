using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : MonoBehaviour
{
    float speed = 1;

    void Update()
    {
        transform.position += Vector3.left * Time.deltaTime * speed;

        if(transform.position.x <= 3)
        {
            speed = 0;
        }
    }
}
