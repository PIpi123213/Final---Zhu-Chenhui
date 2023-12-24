using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class movedirection : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform target; // 标志物的Transform
    public float movementSpeed = 1.0f; // 角色移动速度
    public Animator animator; // 角色的Animator组件

    void Start()
    {
        if (target == null)
        {
            Debug.LogError("Target not assigned to CharacterController!");
        }

        if (animator == null)
        {
            Debug.LogError("Animator not assigned to CharacterController!");
        }
    }

    void Update()
    {
        if (carmove.isstrike)
        {
            movementSpeed = 0f;

        }
        // 计算朝向目标的方向
        Vector3 directionToTarget = (target.position - transform.position).normalized;

        // 使用LookAt方法直接朝向目标
        transform.LookAt(target);

        // 移动角色
        transform.Translate(Vector3.forward * movementSpeed * Time.deltaTime);

        // 设置行走动画的速度
        float moveSpeed = movementSpeed / 1.0f; // 调整这个值来匹配动画的播放速度
        animator.SetFloat("MoveSpeed", moveSpeed);
    }
}
