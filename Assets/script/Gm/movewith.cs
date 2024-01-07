using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movewith : MonoBehaviour
{
    // Start is called before the first frame update
    public Camera targetCamera; // 将你希望用于坐标转换的相机分配给这个变量

    void Update()
    {
        if (targetCamera == null)
        {
            Debug.LogError("Target camera is not assigned!");
            return;
        }

        // 获取鼠标在屏幕上的位置
        Vector3 mousePosition = Input.mousePosition;

        // 将屏幕坐标转换为世界坐标，使用指定的相机
        mousePosition = targetCamera.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, targetCamera.nearClipPlane));

        // 直接设置物体的位置，而不是只更新 x 和 y 坐标
        transform.position = new Vector3(mousePosition.x, mousePosition.y, transform.position.z);
    }
}
