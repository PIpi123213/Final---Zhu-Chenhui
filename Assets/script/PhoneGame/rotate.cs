using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public Camera yourCamera; // ��Inspector�н����ָ��Ϊ����Ҫʹ�õ����

    void Update()
    {
        if (yourCamera == null)
        {
            Debug.LogError("Camera reference not set in the Inspector!");
            return;
        }

        // ��ȡ�������Ļ�ϵ�λ��
        Vector3 mousePos = Input.mousePosition;

        // ���������Ļ�ϵ�λ��ת��Ϊ�������꣬ʹ��ָ�������
        Vector3 targetPos = yourCamera.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, transform.position.z - yourCamera.transform.position.z));

        // ��������ײ����ĵ㵽���λ�õ�����
        Vector3 lookAtDirection = targetPos - new Vector3(transform.position.x, transform.position.y, 0f);

        // ���㳯����귽�����ת�Ƕ�
        float angle = Mathf.Atan2(lookAtDirection.y, lookAtDirection.x) * Mathf.Rad2Deg;

        // �����������ת�Ƕ�
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }
}
