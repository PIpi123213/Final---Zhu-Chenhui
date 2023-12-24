using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explode : MonoBehaviour
{
    // Start is called before the first frame update
    public float explosionForce = 10.0f; // 爆炸力大小
    public float rotationForce = 100.0f;
    public float destroyDelay = 3.0f; // 延迟销毁的时间
    void Start()
    {
        // 在 Start 方法中触发爆炸
        
    }
    private void Update()
    {
        if (characterController.isTrigger)
        {
            
            if (escape.isEscaped)
            {
                Explode();
                escape.isEscaped = false;
                characterController.isTrigger = false;
            }
        }
    }

    IEnumerator DestroyAfterDelay()
    {
        yield return new WaitForSeconds(destroyDelay);

        // 销毁物体
        Destroy(gameObject);
    }
    void Explode()
    {
        // 获取物体上的 Rigidbody 组件
        Rigidbody rb = GetComponent<Rigidbody>();

        // 如果 Rigidbody 组件不为空，给物体施加爆炸力
        if (rb != null)
        {
            // 使用 AddExplosionForce 方法给物体施加爆炸力
            rb.AddExplosionForce(explosionForce, transform.position, 0f);
            rb.AddTorque(Random.onUnitSphere * rotationForce);
            StartCoroutine(DestroyAfterDelay());
        }
        else
        {
            Debug.LogWarning("Rigidbody component not found on the object.");
        }
    }
}
