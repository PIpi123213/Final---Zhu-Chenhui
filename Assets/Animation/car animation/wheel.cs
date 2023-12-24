using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wheel : MonoBehaviour
{
    // Start is called before the first frame update
    public float rotationSpeed = 1.0f; // 旋转速度，可以在Inspector中设置

    
    
        // 获取当前的旋转
        void Update()
        {
            // 使用Rotate方法在物体的局部坐标系中绕X轴旋转
            transform.Rotate(Vector3.right, rotationSpeed * Time.deltaTime);
        }
    
}
