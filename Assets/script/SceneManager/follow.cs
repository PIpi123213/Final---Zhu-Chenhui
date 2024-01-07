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
        // ��ȡ�����Canvas�ϵ�λ��
        Vector2 mousePosition = Input.mousePosition;

        // ����Ļ����ת��ΪCanvas�ϵľֲ�����
        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform, mousePosition, canvas.renderMode == RenderMode.ScreenSpaceOverlay ? null : canvas.worldCamera, out Vector2 localPointerPosition);

        // ���������anchoredPosition
        rectTransform.anchoredPosition = localPointerPosition;
    }
}
