using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class User : MonoBehaviour
{
    Rigidbody rigid;
    float FrontSpeed = 800; // �Է¹��� ĳ������ ���� �ӵ�
    float SideSpeed = 1000; // �Է¹��� ĳ������ �¿� �ӵ�
    float JumpPower=300; // �Է¹��� ĳ������ ���� ����
    float[] SpeedRate = { 1.2f, 1.4f, 1.8f, 2 }; // �Ÿ��� ���� �̵��ӵ�
    bool Jumping;

    public GameObject Item;

    private void Start()
    {
        rigid = GetComponent<Rigidbody>();
        Jumping = false;
    }
    

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
        Jump();

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
        if (Input.GetButtonDown("Jump")) // �����̽��� ������ ����
        {
            if (!Jumping) //�������°� �ƴ϶��, �� �ٴڿ� �ִٸ�
            {
                Jumping = true;
                rigid.AddForce(Vector3.up * JumpPower, ForceMode.Impulse); // y������ ������ ����
            }
            else // �ٴڿ� ���ٸ� ���� ����
            {
                return;
            }


        }

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
            moveSpeed *= SpeedRate[0];
            Debug.Log("ù ��° ���");
        }
        else if (transform.position.z >= 300 && transform.position.z < 500)
        {
            moveSpeed *= SpeedRate[1];
            Debug.Log("�� ��° ���");
        }
        else if (transform.position.z >= 500 && transform.position.z < 700)
        {
            moveSpeed *= SpeedRate[2];
            Debug.Log("�� ��° ���");
        }
        else if (transform.position.z >= 700)
        {
            moveSpeed *= SpeedRate[3];
            Debug.Log("�� ��° ���");
        }

        rigid.velocity = new Vector3(dir.x * SideSpeed, 0, moveSpeed);
       // rigid.AddForce(new Vector3(0, 0, moveSpeed), ForceMode.Impulse);

    }
    private void OnTriggerStay(Collider other)
    {

        if (other.gameObject.name == "MiniGameTest")
        {
            Debug.Log("�̴ϰ��� �浹����");
            FrontSpeed = 0;

            if (Input.GetKey(KeyCode.K))
            {
                Debug.Log("�Է¼���");
                FrontSpeed = 800;
                Move();

            }
            
        }
        else if (other.gameObject.name == "BusterItem")
        {
            Destroy(Item);
            FrontSpeed *= 1.5f;
            Move();
        }
    }


}
