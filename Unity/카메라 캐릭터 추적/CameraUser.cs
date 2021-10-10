using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraUser : MonoBehaviour
{

    public Transform target; // ī�޶� ������ ��� ����
    Vector3 Distance; // ������ ���� ī�޶� ������ �Ÿ�

    private void Awake()
    {
        if ( target != null) // ������ ����� �ִٸ�
        {
            Distance = transform.position - target.position; // ī�޶�� ĳ���� ������ �Ÿ� ���

        }
    }

    private void LateUpdate()
    {
        if (target == null) // ������ ����� ���ٸ� ����
            return;

        Vector3 position = target.position + Distance; // ĳ������ ��ġ�� ī�޶� ������ �Ÿ��� ����
        position.x = 0; // �¿� ������ ����
        transform.position = position; // ����� �Ÿ��� ī�޶��� ��ġ�� ����
    }


}
