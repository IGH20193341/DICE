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

    public GameObject Item;

    private void Start()
    {
        rigid = GetComponent<Rigidbody>();
        Jumping = false;
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump")) // �����̽��� ������ ����
        {
            Jumping = true;
            Jump();
        }
    }

    void FixedUpdate()
    {
        Move();

    }

    void Jump()
    {
        if (!Jumping)
        {
            return;
        }

        rigid.AddForce(Vector3.up * JumpPower, ForceMode.Impulse); // y������ ������ ����
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

        transform.Translate(dir.x * SideSpeed, 0, moveSpeed);


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
