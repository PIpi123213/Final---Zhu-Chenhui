using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerfollow : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform target; // 要跟随的目标（例如玩家角色）
    public float smoothSpeed = 0.125f; // 平滑度，数值越小，跟随越平滑

    private Vector3 offset; // 初始相对位置

    void Start()
    {
        if (target != null)
        {
            // 计算初始相对位置
            offset = transform.position - target.position;
        }
    }

    void LateUpdate()
    {
        if (target != null)
        {
            // 计算新的相机位置
            Vector3 desiredPosition = target.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;

            // 如果需要，你还可以调整相机的旋转，使其朝向目标
            // transform.LookAt(target);
        }
    }
}
