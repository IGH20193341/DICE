using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoiceEventEnemy : MonoBehaviour
{
    float speed = 7;
    public GameObject user;
    Vector3 zDistance;

    void Update()
    {
        
        if(user != null) {
            zDistance.z = transform.position.z - user.transform.position.z;

            if (zDistance.z <= 200 && zDistance.z >= -50f)
            {
                User.JumpPower = 0;
                if (User.dbVal >= -60f)
                    transform.position += Vector3.up * Time.deltaTime * speed;
            }

            else
                User.JumpPower = 12;
        }
    }
}
