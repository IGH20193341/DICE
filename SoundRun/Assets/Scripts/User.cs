using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class User : MonoBehaviour
{
    Rigidbody rigid;
    public float FrontSpeed; // �Է¹��� ĳ������ ���� �ӵ�
    public float SideSpeed; // �Է¹��� ĳ������ �¿� �ӵ�
    public float JumpPower; // �Է¹��� ĳ������ ���� ����
    float[] SpeedRate = { 1.2f, 1.4f, 1.8f, 2 }; // �Ÿ��� ���� �̵��ӵ�
    bool Jumping;

    private void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }
    

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();

        if (Input.GetButtonDown("Jump")) // �����̽��� ������ ����
        {
            Jumping = true;
            Jump();

        }

        //MoveFront();

    }
    //void MoveFront()
    //{

    //    float h = Input.GetAxisRaw("Horizontal");
    //    float v = Input.GetAxisRaw("Vertical");
    //    rigid.velocity = new Vector3(0, 0, moveSpeed); // z������ �̵�
    //    rigid.AddForce(new Vector3(h, 0, v), ForceMode.Impulse);

    //}

    void Jump()
    {
        if (!Jumping) // ������ �ƴ϶�� ����
            return;

        rigid.AddForce(new Vector3(0, JumpPower,0 ), ForceMode.Impulse) ; // y������ ������ ����

        Jumping = false;
    }

    public void Move()
    {
        float moveSpeed = Time.fixedDeltaTime * FrontSpeed; // ĳ������ �ӵ� ���
        Vector3 dir = Vector3.zero;

        dir.x = Input.acceleration.x;

        if (dir.sqrMagnitude > 1)
            dir.Normalize();

        dir *= Time.deltaTime;

        if (transform.position.z >= 100 && transform.position.z < 300)
        {
            Debug.Log("1.2��");
            moveSpeed *= SpeedRate[0];
            Debug.Log("����1");
        }
        else if (transform.position.z >= 300 && transform.position.z < 500)
        {
            Debug.Log("1.4��");
            moveSpeed *= SpeedRate[1];
            Debug.Log("����2");
        }
        else if (transform.position.z >= 500 && transform.position.z < 700)
        {
            Debug.Log("1.6��");
            moveSpeed *= SpeedRate[2];
            Debug.Log("����3");
        }
        else if (transform.position.z >= 700)
        {
            Debug.Log("2��");
            moveSpeed *= SpeedRate[3];
            Debug.Log("����4");
        }

        rigid.velocity = new Vector3(dir.x * SideSpeed, 0, 0);
        rigid.AddForce(new Vector3(0, 0, moveSpeed), ForceMode.Impulse);

    }


}
