using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carmove : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveSpeed = 5.0f; // 移动速度，可以在Inspector中设置
    public static bool isstrike = false;
    void Update()
    {
        // 获取物体的Transform组件
        Transform objectTransform = transform;

        // 计算移动方向（物体的前方方向）
        Vector3 moveDirection = objectTransform.forward;

        // 将移动方向标准化，并乘以速度
        Vector3 moveAmount = moveDirection.normalized * moveSpeed;

        // 使用Translate方法移动物体
        objectTransform.Translate(-moveAmount * Time.deltaTime);
    }
    void OnCollisionEnter(Collision collision)
    {

        // 检测碰撞的物体是否有 "car" 标签
        if (collision.gameObject.CompareTag("Player"))
        {
            moveSpeed = 0f;
            isstrike = true;
            /*Collider myCollider = GetComponent<Collider>();
            if (myCollider != null)
            {
                myCollider.enabled = false;
            }*/
        }
    }
}
