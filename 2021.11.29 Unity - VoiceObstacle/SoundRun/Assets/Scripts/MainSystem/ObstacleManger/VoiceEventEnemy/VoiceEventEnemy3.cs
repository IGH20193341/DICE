using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoiceEventEnemy3 : MonoBehaviour
{
    float speed = 5;
    public GameObject user;
    public GameObject VEE2; //VoiceEventEnemy2

    void Update()
    {

        if (user != null)
        {
            if (User.dbVal >= -60f && VEE2.transform.position.y >= 8f)
                transform.position += Vector3.up * Time.deltaTime * speed;
        }
    }
}
