using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject projectilePrefab; // ��Inspector��ָ��Ҫ�����С���Ԥ����
    public Transform shootPoint; // ��Inspector��ָ�������

    void Update()
    {
        // ����������Ƿ���
        if (Input.GetMouseButtonDown(0))
        {
            ShootProjectile();
        }
    }

    void ShootProjectile()
    {
        // ����Ƿ�������Ҫ�����Ԥ����ͷ����
        if (projectilePrefab != null && shootPoint != null)
        {
            // ʵ����������С��
            GameObject projectile = Instantiate(projectilePrefab, shootPoint.position, Quaternion.identity);
            projectile.transform.parent = transform.parent;
            // ��С�������ǰ����
            Rigidbody2D projectileRb = projectile.GetComponent<Rigidbody2D>();
            if (projectileRb != null)
            {
                projectileRb.AddForce(shootPoint.right * 3f, ForceMode2D.Impulse);
            }
            else
            {
                Debug.LogWarning("Rigidbody2D not found on projectile prefab.");
            }
        }
        else
        {
            Debug.LogWarning("Projectile prefab or shoot point not assigned.");
        }
    }
}
