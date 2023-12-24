using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shake : MonoBehaviour
{
    // Start is called before the first frame update
    public float shakeAmount = 0.1f; // 晃动幅度，可以在Inspector中设置
    public float shakeSpeed = 5.0f; // 晃动速度，可以在Inspector中设置

    private Vector3 originalScale;

    void Start()
    {
        // 记录图片的初始缩放
        originalScale = transform.localScale;
    }

    void Update()
    {
        if (!characterController.isTrigger)
        {
            Destroy(gameObject);


        }
        // 计算晃动效果
        float scaleChange = Mathf.Sin(Time.time * shakeSpeed) * shakeAmount;

        // 应用晃动效果到图片的缩放
        transform.localScale = originalScale + new Vector3(scaleChange, scaleChange, 0f);
    }
}
