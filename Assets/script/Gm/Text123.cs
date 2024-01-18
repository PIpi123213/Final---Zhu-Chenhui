using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Text123 : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] textObjects; // 以数组形式存储所有的文本对象
    private int currentIndex = 0; // 当前显示的文本索引
    public static bool isCreate=false;
    public static bool isCreate2 = false;
    public float[] delays; // 存储每个文本显示的延迟时间

    void Start()
    {
        // 初始化，确保文本对象处于初始状态
        SetTextObjectsActive(false);

        // 调用示例：过 delays[0] 秒后显示第一个文本
        if (GameManager.isFirst)
        {
            Invoke("ShowText", delays[0]);
            isCreate = false;
            isCreate2 = false;
        }
        

    }
    private void Update()
    {
        if (currentIndex == 2)
        {
            isCreate = true;

        }
        if (GameManager.isStart)
        {
            for(int i=0 ; i< textObjects.Length; i++)
            {
                textObjects[i].SetActive(false);
            }
            
        }
    }
    void SetTextObjectsActive(bool active)
    {
        foreach (var textObject in textObjects)
        {
            textObject.SetActive(active);
        }
    }

    void ShowText()
    {
        // 隐藏之前显示的文本
        if (currentIndex > 0)
        {
            textObjects[currentIndex - 1].SetActive(false);
        }

        // 显示当前文本
        if (currentIndex < textObjects.Length)
        {
            textObjects[currentIndex].SetActive(true);
            if (currentIndex == 3)
            {
                isCreate2 = true;
            }
            else
            {
                isCreate2 = false;
            }
            // 调用示例：过 delays[currentIndex + 1] 秒后显示下一个文本
            Invoke("ShowText", delays[currentIndex + 1]);
            currentIndex++;
        }
    }

}
