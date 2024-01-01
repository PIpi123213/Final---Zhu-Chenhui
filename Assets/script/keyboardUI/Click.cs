using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Click : MonoBehaviour
{
    // Start is called before the first frame update
    public float decreaseSpeed = 0.1f; // 进度条减少速度
    public float maxProgress = 1f; // 进度条最大值
    public float timeLimit = 10f; // 时间限制
    public KeyCode targetKey = KeyCode.Space; // 目标按键
    public float currentProgress = 0.3f;

    public Slider progressBar;

    void Start()
    {
        progressBar.value = Mathf.Clamp01(currentProgress);
    }

    void Update()
    {
        if (progressBar.value >= maxProgress)
        {
            // 如果进度条满了，显示成功文本
            
            return;
        }

        // 如果按下指定按键，增加进度
        if (Input.GetKeyDown(targetKey))
        {
            progressBar.value += 0.1f; // 可根据需要调整增加的值
        }

        // 减少进度条
        progressBar.value = Mathf.MoveTowards(progressBar.value, 0f, decreaseSpeed * Time.deltaTime);

        // 如果时间超过限制，显示失败文本
        if (progressBar.value <= 0f)
        {
            
        }
    }
}
