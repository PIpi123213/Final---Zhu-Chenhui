using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontTouch : MonoBehaviour
{
  
    
    void Start()
    {
        

    }
    void Update()
    {
        escape component1 = GetComponent<escape>();
        if (component1.isEscaped)
        {
            // ��ȡ�����ϵ����� Collider ���
            Collider[] colliders = GetComponents<Collider>();

            // ��ÿ�� Collider ����Ϊ����Ծ
            foreach (Collider collider in colliders)
            {
                collider.enabled = false;
            }
        }
        else
        {
            Collider[] colliders = GetComponents<Collider>();

            // ��ÿ�� Collider ����Ϊ����Ծ
            foreach (Collider collider in colliders)
            {
                collider.enabled = true;
            }
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        { 
            characterController.isDead = true;
        }
    }

}
