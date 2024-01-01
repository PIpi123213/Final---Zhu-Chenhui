using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wheel : MonoBehaviour
{
    // Start is called before the first frame update
    public float rotationSpeed = 1.0f;

    // 选择绕哪个轴旋转的枚举类型
    public enum RotationAxis
    {
        X,
        Y,
        Z
    }

    public RotationAxis rotationAxis = RotationAxis.X; // 默认绕X轴旋转

    // 获取当前的旋转
    void Update()
    {
        // 使用 Rotate 方法在物体的局部坐标系中绕选定的轴旋转
        switch (rotationAxis)
        {
            case RotationAxis.X:
                transform.Rotate(Vector3.right, rotationSpeed * Time.deltaTime);
                break;
            case RotationAxis.Y:
                transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
                break;
            case RotationAxis.Z:
                transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
                break;
            default:
                break;
        }
    }

}
