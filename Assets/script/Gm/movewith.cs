using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movewith : MonoBehaviour
{
    // Start is called before the first frame update
    public Camera targetCamera; // ����ϣ����������ת�������������������

    void Update()
    {
        if (targetCamera == null)
        {
            Debug.LogError("Target camera is not assigned!");
            return;
        }

        // ��ȡ�������Ļ�ϵ�λ��
        Vector3 mousePosition = Input.mousePosition;

        // ����Ļ����ת��Ϊ�������꣬ʹ��ָ�������
        mousePosition = targetCamera.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, targetCamera.nearClipPlane));

        // ֱ�����������λ�ã�������ֻ���� x �� y ����
        transform.position = new Vector3(mousePosition.x, mousePosition.y, transform.position.z);
    }
}
