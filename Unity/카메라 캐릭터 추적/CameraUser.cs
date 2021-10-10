using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraUser : MonoBehaviour
{

    public Transform target; // 카메라가 추적할 대상 설정
    Vector3 Distance; // 추적할 대상과 카메라 사이의 거리

    private void Awake()
    {
        if ( target != null) // 추적할 대상이 있다면
        {
            Distance = transform.position - target.position; // 카메라와 캐릭터 사이의 거리 계산

        }
    }

    private void LateUpdate()
    {
        if (target == null) // 추적할 대상이 없다면 리턴
            return;

        Vector3 position = target.position + Distance; // 캐릭터의 위치와 카메라 사이의 거리를 더함
        position.x = 0; // 좌우 움직임 봉인
        transform.position = position; // 계산한 거리를 카메라의 위치에 저장
    }


}
