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
            // 获取物体上的所有 Collider 组件
            Collider[] colliders = GetComponents<Collider>();

            // 将每个 Collider 设置为不活跃
            foreach (Collider collider in colliders)
            {
                collider.enabled = false;
            }
        }
        else
        {
            Collider[] colliders = GetComponents<Collider>();

            // 将每个 Collider 设置为不活跃
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
