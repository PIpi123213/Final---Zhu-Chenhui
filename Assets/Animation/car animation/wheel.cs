using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wheel : MonoBehaviour
{
    // Start is called before the first frame update
    public float rotationSpeed = 1.0f; // ��ת�ٶȣ�������Inspector������

    
    
        // ��ȡ��ǰ����ת
        void Update()
        {
            // ʹ��Rotate����������ľֲ�����ϵ����X����ת
            transform.Rotate(Vector3.right, rotationSpeed * Time.deltaTime);
        }
    
}
