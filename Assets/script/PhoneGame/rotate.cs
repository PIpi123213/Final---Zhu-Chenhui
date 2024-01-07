using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public Camera yourCamera; // 在Inspector中将相机指定为你想要使用的相机

    void Update()
    {
        if (yourCamera == null)
        {
            Debug.LogError("Camera reference not set in the Inspector!");
            return;
        }

        // 获取鼠标在屏幕上的位置
        Vector3 mousePos = Input.mousePosition;

        // 将鼠标在屏幕上的位置转换为世界坐标，使用指定的相机
        Vector3 targetPos = yourCamera.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, transform.position.z - yourCamera.transform.position.z));

        // 设置物体底部中心点到鼠标位置的向量
        Vector3 lookAtDirection = targetPos - new Vector3(transform.position.x, transform.position.y, 0f);

        // 计算朝向鼠标方向的旋转角度
        float angle = Mathf.Atan2(lookAtDirection.y, lookAtDirection.x) * Mathf.Rad2Deg;

        // 设置物体的旋转角度
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }
}
