using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateHappen : MonoBehaviour
{
    // Start is called before the first frame update
    public bool isrotate = false;
    void OnTriggerEnter(Collider other)
    {
        // �����ײ�������Ƿ��� "Player" ��ǩ
        if (other.CompareTag("Player"))
        {
            isrotate = true;



        }
        // �ڿ���̨���������Ϣ


    }
}
