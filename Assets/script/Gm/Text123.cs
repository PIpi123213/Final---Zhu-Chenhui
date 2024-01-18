using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Text123 : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] textObjects; // ��������ʽ�洢���е��ı�����
    private int currentIndex = 0; // ��ǰ��ʾ���ı�����
    public static bool isCreate=false;
    public static bool isCreate2 = false;
    public float[] delays; // �洢ÿ���ı���ʾ���ӳ�ʱ��

    void Start()
    {
        // ��ʼ����ȷ���ı������ڳ�ʼ״̬
        SetTextObjectsActive(false);

        // ����ʾ������ delays[0] �����ʾ��һ���ı�
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
        // ����֮ǰ��ʾ���ı�
        if (currentIndex > 0)
        {
            textObjects[currentIndex - 1].SetActive(false);
        }

        // ��ʾ��ǰ�ı�
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
            // ����ʾ������ delays[currentIndex + 1] �����ʾ��һ���ı�
            Invoke("ShowText", delays[currentIndex + 1]);
            currentIndex++;
        }
    }

}
