using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Click : MonoBehaviour
{
    // Start is called before the first frame update
    public float decreaseSpeed = 0.1f; // �����������ٶ�
    public float maxProgress = 1f; // ���������ֵ
    public float timeLimit = 10f; // ʱ������
    public KeyCode targetKey = KeyCode.Space; // Ŀ�갴��
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
            // ������������ˣ���ʾ�ɹ��ı�
            
            return;
        }

        // �������ָ�����������ӽ���
        if (Input.GetKeyDown(targetKey))
        {
            progressBar.value += 0.1f; // �ɸ�����Ҫ�������ӵ�ֵ
        }

        // ���ٽ�����
        progressBar.value = Mathf.MoveTowards(progressBar.value, 0f, decreaseSpeed * Time.deltaTime);

        // ���ʱ�䳬�����ƣ���ʾʧ���ı�
        if (progressBar.value <= 0f)
        {
            
        }
    }
}
