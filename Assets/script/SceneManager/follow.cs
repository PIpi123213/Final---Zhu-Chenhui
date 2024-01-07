using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class follow : MonoBehaviour
{
    // Start is called before the first frame update
    private RectTransform rectTransform;
    public Canvas canvas;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        
    }

    void Update()
    {
        // 获取鼠标在Canvas上的位置
        Vector2 mousePosition = Input.mousePosition;

        // 将屏幕坐标转换为Canvas上的局部坐标
        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform, mousePosition, canvas.renderMode == RenderMode.ScreenSpaceOverlay ? null : canvas.worldCamera, out Vector2 localPointerPosition);

        // 设置物体的anchoredPosition
        rectTransform.anchoredPosition = localPointerPosition;
    }
}
