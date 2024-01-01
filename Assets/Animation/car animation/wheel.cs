using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wheel : MonoBehaviour
{
    // Start is called before the first frame update
    public float rotationSpeed = 1.0f;

    // ѡ�����ĸ�����ת��ö������
    public enum RotationAxis
    {
        X,
        Y,
        Z
    }

    public RotationAxis rotationAxis = RotationAxis.X; // Ĭ����X����ת

    // ��ȡ��ǰ����ת
    void Update()
    {
        // ʹ�� Rotate ����������ľֲ�����ϵ����ѡ��������ת
        switch (rotationAxis)
        {
            case RotationAxis.X:
                transform.Rotate(Vector3.right, rotationSpeed * Time.deltaTime);
                break;
            case RotationAxis.Y:
                transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
                break;
            case RotationAxis.Z:
                transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
                break;
            default:
                break;
        }
    }

}
