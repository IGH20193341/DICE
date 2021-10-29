using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround1 : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject User;
    Vector3 Distance;

    void Start()
    {
        Distance = transform.position - User.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 position = User.transform.position + Distance;
        position.x = 0;
        position.y = 0;
        transform.position = position;

        if (transform.position.z >= 200)
        {
            Destroy(gameObject);
        }
    }
}
