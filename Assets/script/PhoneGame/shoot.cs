using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject projectilePrefab; // 在Inspector中指定要发射的小球的预制体
    public Transform shootPoint; // 在Inspector中指定发射点

    void Update()
    {
        // 检测鼠标左键是否按下
        if (Input.GetMouseButtonDown(0))
        {
            ShootProjectile();
        }
    }

    void ShootProjectile()
    {
        // 检查是否设置了要发射的预制体和发射点
        if (projectilePrefab != null && shootPoint != null)
        {
            // 实例化并发射小球
            GameObject projectile = Instantiate(projectilePrefab, shootPoint.position, Quaternion.identity);
            projectile.transform.parent = transform.parent;
            // 给小球添加向前的力
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
