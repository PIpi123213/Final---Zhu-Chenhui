using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class start : MonoBehaviour
{
    // Start is called before the first frame update
    
    public bool isstart = false;
    void OnTriggerEnter(Collider other)
    {
        // 检测碰撞的物体是否有 "Player" 标签
        if (other.CompareTag("Player"))
        {
            isstart = true;



         }
            // 在控制台输出调试信息


    }
}

