using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destory : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // 调用延迟销毁的协程
        StartCoroutine(DestroyAfterDelay(5.0f));
    }

    IEnumerator DestroyAfterDelay(float delay)
    {
        // 等待指定的时间
        yield return new WaitForSeconds(delay);

        // 销毁物体
        Destroy(gameObject);
    }
}
