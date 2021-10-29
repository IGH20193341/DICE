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

    private void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }
    

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();

        if (Input.GetButtonDown("Jump")) // 스페이스를 누르면 점프
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
    //    rigid.velocity = new Vector3(0, 0, moveSpeed); // z축으로 이동
    //    rigid.AddForce(new Vector3(h, 0, v), ForceMode.Impulse);

    //}

    void Jump()
    {
        if (!Jumping) // 점프가 아니라면 리턴
            return;

        rigid.AddForce(new Vector3(0, JumpPower,0 ), ForceMode.Impulse) ; // y축으로 점프할 높이

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
            Debug.Log("1.2배");
            moveSpeed *= SpeedRate[0];
            Debug.Log("성공1");
        }
        else if (transform.position.z >= 300 && transform.position.z < 500)
        {
            Debug.Log("1.4배");
            moveSpeed *= SpeedRate[1];
            Debug.Log("성공2");
        }
        else if (transform.position.z >= 500 && transform.position.z < 700)
        {
            Debug.Log("1.6배");
            moveSpeed *= SpeedRate[2];
            Debug.Log("성공3");
        }
        else if (transform.position.z >= 700)
        {
            Debug.Log("2배");
            moveSpeed *= SpeedRate[3];
            Debug.Log("성공4");
        }

        rigid.velocity = new Vector3(dir.x * SideSpeed, 0, 0);
        rigid.AddForce(new Vector3(0, 0, moveSpeed), ForceMode.Impulse);

    }


}
