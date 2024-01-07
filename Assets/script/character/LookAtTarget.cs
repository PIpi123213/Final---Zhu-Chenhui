using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtTarget : MonoBehaviour
{
    // Start is called before the first frame update
    private Quaternion initialRotation;
    public float rotationSpeed = 0.5f;
     void Start()
    {
        initialRotation = transform.rotation;
    }
    void Update()
    {
        // 检查是否有目标


        // 获取目标方向
        float t = Time.deltaTime * rotationSpeed;
        transform.rotation = Quaternion.Slerp(transform.rotation, initialRotation, t);

    }
}
