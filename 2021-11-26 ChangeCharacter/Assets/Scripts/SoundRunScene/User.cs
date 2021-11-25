using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class User : MonoBehaviour
{
    Rigidbody rigid;
    public float FrontSpeed; // 입력받을 캐릭터의 정면 속도
    public float SideSpeed; // 입력받을 캐릭터의 좌우 속도
    public float JumpPower; // 입력받을 캐릭터의 점프 높이
    float[] SpeedRate = { 1.2f, 1.4f, 1.8f, 2 }; // 거리에 따른 이동속도
    bool Jumping;

    public GameObject Item;

    private void Start()
    {
        rigid = GetComponent<Rigidbody>();
        Jumping = false;
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump")) // 스페이스를 누르면 점프
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

        rigid.AddForce(Vector3.up * JumpPower, ForceMode.Impulse); // y축으로 점프할 높이
        Jumping = false;

    }

    public void Move()
    {
        float moveSpeed = Time.fixedDeltaTime * FrontSpeed; // 캐릭터의 속도 계산
        Vector3 dir = Vector3.zero;

        dir.x = Input.acceleration.x;

        if (dir.sqrMagnitude > 1)
            dir.Normalize();

        dir *= Time.deltaTime;

        if (transform.position.z >= 100 && transform.position.z < 300)
        {
            moveSpeed *= SpeedRate[0];
            Debug.Log("첫 번째 배속");
        }
        else if (transform.position.z >= 300 && transform.position.z < 500)
        {
            moveSpeed *= SpeedRate[1];
            Debug.Log("두 번째 배속");
        }
        else if (transform.position.z >= 500 && transform.position.z < 700)
        {
            moveSpeed *= SpeedRate[2];
            Debug.Log("세 번째 배속");
        }
        else if (transform.position.z >= 700)
        {
            moveSpeed *= SpeedRate[3];
            Debug.Log("네 번째 배속");
        }

        transform.Translate(dir.x * SideSpeed, 0, moveSpeed);


    }
    private void OnTriggerStay(Collider other)
    {

        if (other.gameObject.name == "MiniGameTest")
        {
            Debug.Log("미니게임 충돌감지");
            FrontSpeed = 0;

            if (Input.GetKey(KeyCode.K))
            {
                Debug.Log("입력성공");
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
