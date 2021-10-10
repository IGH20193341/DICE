using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class User : MonoBehaviour
{
    Rigidbody rigid;
    public float UserSpeed;
    float JumpPower = 10f;
    bool Jumping;

    private void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        Usermove();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jumping = true;
            Jump();

        }

    }
    void Usermove()
    {
          float moveSpeed = Time.fixedDeltaTime * UserSpeed;
        //  rigid.AddForce(new Vector3(0, 0, moveAmount), ForceMode.Impulse);

        rigid.velocity = new Vector3(0, 0, moveSpeed);
    }

    void Jump()
    {
        if (!Jumping)
            return;

        rigid.velocity = new Vector3(0, JumpPower, 0);

        Jumping = false;
    }
}
