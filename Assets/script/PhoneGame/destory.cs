using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destory : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // �����ӳ����ٵ�Э��
        StartCoroutine(DestroyAfterDelay(5.0f));
    }

    IEnumerator DestroyAfterDelay(float delay)
    {
        // �ȴ�ָ����ʱ��
        yield return new WaitForSeconds(delay);

        // ��������
        Destroy(gameObject);
    }
}
