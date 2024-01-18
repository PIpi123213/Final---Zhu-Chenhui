using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explode : MonoBehaviour
{
    // Start is called before the first frame update
    public float explosionForce = 10.0f; // ��ը����С
    public float rotationForce = 100.0f;
    public float destroyDelay = 3.0f; // �ӳ����ٵ�ʱ��
    void Start()
    {
        // �� Start �����д�����ը
        

    }
    void Update()
    {
        escape component1 = GetComponent<escape>();
        
        if (component1.isEscaped)
            {
            Debug.Log("333");
            Debug.Log(gameObject.name);
            explodeforce();
            }
        
    }

    IEnumerator DestroyAfterDelay()
    {
        yield return new WaitForSeconds(destroyDelay);
        
        // ��������
        Destroy(gameObject);
    }
    public void explodeforce()
    {
        
        // ��ȡ�����ϵ� Rigidbody ���
        Rigidbody rb = GetComponent<Rigidbody>();

        // ��� Rigidbody �����Ϊ�գ�������ʩ�ӱ�ը��
        if (rb != null)
        {
            // ʹ�� AddExplosionForce ����������ʩ�ӱ�ը��
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
