using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shake : MonoBehaviour
{
    // Start is called before the first frame update
    public float shakeAmount = 0.1f; // �ζ����ȣ�������Inspector������
    public float shakeSpeed = 5.0f; // �ζ��ٶȣ�������Inspector������

    private Vector3 originalScale;

    void Start()
    {
        // ��¼ͼƬ�ĳ�ʼ����
        originalScale = transform.localScale;
    }

    void Update()
    {
        if (!characterController.isTrigger)
        {
            Destroy(gameObject);


        }
        // ����ζ�Ч��
        float scaleChange = Mathf.Sin(Time.time * shakeSpeed) * shakeAmount;

        // Ӧ�ûζ�Ч����ͼƬ������
        transform.localScale = originalScale + new Vector3(scaleChange, scaleChange, 0f);
    }
}
