using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCar : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform target; // 目标的Transform组件
    public float rotationSpeed = 8.0f;
    public RotateHappen rotateHappen;
    void Update()
    {
        // 检查是否有目标

        if (rotateHappen.isrotate)
        {
            if (target != null)
            {
                // 获取目标方向
                Vector3 targetDirection = target.position - transform.position;

                // 计算旋转角度（只考虑水平方向）
                float angle = Mathf.Atan2(targetDirection.x, targetDirection.y) * Mathf.Rad2Deg;

                // 使用Quaternion.Euler进行只在y轴上的旋转
                Quaternion targetRotation = Quaternion.Euler(0, angle, 0);

                // 应用旋转
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
            }

        }
       
    }
}
