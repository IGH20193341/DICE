using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoiceEventEnemy2 : MonoBehaviour
{
    float speed = 5;
    public GameObject user;
    public GameObject VEE; //VoiceEventEnemy

    void Update()
    {

        if (user != null)
        {
            if (User.dbVal >= -60f && VEE.transform.position.y >= 8f)
                transform.position += Vector3.up * Time.deltaTime * speed;
        }
    }
}
