using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class start : MonoBehaviour
{
    // Start is called before the first frame update
    
    public bool isstart = false;
    void OnTriggerEnter(Collider other)
    {
        // �����ײ�������Ƿ��� "Player" ��ǩ
        if (other.CompareTag("Player"))
        {
            isstart = true;



         }
            // �ڿ���̨���������Ϣ


    }
}

