using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerfollow : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform target; // Ҫ�����Ŀ�꣨������ҽ�ɫ��
    public float smoothSpeed = 0.125f; // ƽ���ȣ���ֵԽС������Խƽ��

    private Vector3 offset; // ��ʼ���λ��

    void Start()
    {
        if (target != null)
        {
            // �����ʼ���λ��
            offset = transform.position - target.position;
        }
    }

    void LateUpdate()
    {
        if (target != null)
        {
            // �����µ����λ��
            Vector3 desiredPosition = target.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;

            // �����Ҫ���㻹���Ե����������ת��ʹ�䳯��Ŀ��
            // transform.LookAt(target);
        }
    }
}
