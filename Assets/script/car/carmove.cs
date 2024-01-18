using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carmove : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveSpeed = 0f; // 移动速度，可以在Inspector中设置
    public float speed = 5.0f;
    //public static bool isstrike = false;
    public start start;
    private bool hasStarted = false;
    private escape escape1;
    void Start()
    {
        escape1 = GetComponent<escape>();

    }
    void Update()
    {
        if (start.isstart && !characterController.isDead)
        {
            
            if (!hasStarted)
            {
                // 第一次满足条件，执行操作
                moveSpeed = speed;
                hasStarted = true;
                
                
                // 将标志设置为 true，防止再次执行
            }
        }

        if (escape1.isEscaped)
        {

            moveSpeed = 0f;
        }
        // 获取物体的Transform组件
        Transform objectTransform = transform;

        // 计算移动方向（物体的前方方向）
        Vector3 moveDirection = objectTransform.forward;


        // 将移动方向标准化，并乘以速度
        Vector3 moveAmount = moveDirection.normalized * moveSpeed;

        // 使用Translate方法移动物体
        objectTransform.Translate(moveAmount * Time.deltaTime, Space.World);
    }
    void OnCollisionEnter(Collision collision)
    {

        // 检测碰撞的物体是否有 "car" 标签
        if (collision.gameObject.CompareTag("Player"))
        {
            
            
            characterController.isDead = true;
            enabled = false;
        }
    }
}
